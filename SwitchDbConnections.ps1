<#
.SYNOPSIS
    Swaps ConnectionStrings.Database in Access project production appsettings
    with the Development equivalent for local EF migrations, then reverts.

.PARAMETER production
    Debug  - Copy ConnectionStrings.Database from appsettings.Development.json
             into the production appsettings file and save the original value.
    Release - Revert the production appsettings file using the saved backup.

.EXAMPLE
    .\SwitchDbConnections.ps1 Debug
    .\SwitchDbConnections.ps1 Release
#>
param(
    [Parameter(Mandatory, Position = 0)]
    [ValidateSet('Debug', 'Release')]
    [string]$production
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

$accessRoot   = Join-Path $PSScriptRoot "SalesSystem\src\Access"
$backupSuffix = ".connectionstring.backup.json"

if (-not (Test-Path $accessRoot)) {
    Write-Error "Access root not found: $accessRoot"
    exit 1
}

function Get-ConnectionString {
    param([PSCustomObject]$config)
    try {
        return [string]$config.ConnectionStrings.Database
    }
    catch {
        return $null
    }
}

# Discover project directories that contain appsettings.Development.json, excluding bin/obj output folders
[string[]]$projectDirs = Get-ChildItem -Path $accessRoot -Recurse -Filter "appsettings.Development.json" |
    Where-Object { $_.FullName -notmatch '\\(bin|obj)\\' } |
    Select-Object -ExpandProperty DirectoryName |
    Sort-Object -Unique

if ($projectDirs.Count -eq 0) {
    Write-Warning "No appsettings.Development.json files found under $accessRoot"
    exit 0
}

foreach ($projectDir in $projectDirs) {
    $projectName   = Split-Path $projectDir -Leaf
    $devConfigPath = Join-Path $projectDir "appsettings.Development.json"

    # Prefer appsettings.Production.json; fall back to appsettings.json
    $prodConfigPath = Join-Path $projectDir "appsettings.Production.json"
    if (-not (Test-Path $prodConfigPath)) {
        $prodConfigPath = Join-Path $projectDir "appsettings.json"
    }

    if (-not (Test-Path $prodConfigPath)) {
        Write-Host "[$projectName] No production appsettings file found — skipping."
        continue
    }

    $backupPath = Join-Path $projectDir ($projectName + $backupSuffix)

    # ── DEBUG: patch production with dev connection string ──────────────────
    if ($production -eq 'Debug') {
        $devConfig  = Get-Content $devConfigPath  -Raw | ConvertFrom-Json
        $prodConfig = Get-Content $prodConfigPath -Raw | ConvertFrom-Json

        [string]$devConnStr  = Get-ConnectionString $devConfig
        [string]$prodConnStr = Get-ConnectionString $prodConfig

        if ([string]::IsNullOrWhiteSpace($devConnStr)) {
            Write-Host "[$projectName] No ConnectionStrings.Database in $devConfigPath — skipping."
            continue
        }

        if ([string]::IsNullOrWhiteSpace($prodConnStr)) {
            Write-Host "[$projectName] No ConnectionStrings.Database in $prodConfigPath — skipping."
            continue
        }

        if ($devConnStr -eq $prodConnStr) {
            Write-Host "[$projectName] Connection strings already match — no change needed."
            continue
        }

        if (Test-Path $backupPath) {
            Write-Warning "[$projectName] Backup already exists at '$backupPath'. Run with Release first to revert."
            continue
        }

        # Persist the original production value so it can be restored later
        [PSCustomObject]@{
            ProjectName              = $projectName
            ProductionConfigFile     = $prodConfigPath
            OriginalConnectionString = $prodConnStr
        } | ConvertTo-Json -Depth 3 | Set-Content -Path $backupPath -Encoding UTF8

        $prodConfig.ConnectionStrings.Database = $devConnStr
        $prodConfig | ConvertTo-Json -Depth 10 | Set-Content -Path $prodConfigPath -Encoding UTF8

        Write-Host "[$projectName] Patched '$prodConfigPath' with Development connection string."
        Write-Host "[$projectName] Backup saved to '$backupPath'."
    }

    # ── RELEASE: revert production back to the original value ───────────────
    elseif ($production -eq 'Release') {
        if (-not (Test-Path $backupPath)) {
            Write-Host "[$projectName] No backup found — nothing to revert."
            continue
        }

        $backup     = Get-Content $backupPath     -Raw | ConvertFrom-Json
        $prodConfig = Get-Content $prodConfigPath -Raw | ConvertFrom-Json

        [string]$originalConnStr = Get-ConnectionString $backup

        if ([string]::IsNullOrWhiteSpace($originalConnStr)) {
            Write-Warning "[$projectName] Backup has no OriginalConnectionString — cannot revert safely."
            continue
        }

        $prodConfig.ConnectionStrings.Database = $originalConnStr
        $prodConfig | ConvertTo-Json -Depth 10 | Set-Content -Path $prodConfigPath -Encoding UTF8

        Remove-Item $backupPath -Force
        Write-Host "[$projectName] Reverted '$prodConfigPath' to original connection string. Backup removed."
    }
}