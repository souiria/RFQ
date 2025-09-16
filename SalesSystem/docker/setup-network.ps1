# Setup shared Docker network for container connectivity
Write-Host "Setting up shared Docker network..." -ForegroundColor Green

# Create the shared network if it doesn't exist
$networkExists = docker network ls --filter name=shared-dev-network --format "{{.Name}}"
if (-not $networkExists) {
    Write-Host "Creating shared-dev-network..." -ForegroundColor Yellow
    docker network create shared-dev-network --driver bridge --subnet=172.25.0.0/16
    Write-Host "Network created successfully!" -ForegroundColor Green
} else {
    Write-Host "Network 'shared-dev-network' already exists." -ForegroundColor Blue
}

# Display network information
Write-Host "`nNetwork details:" -ForegroundColor Cyan
docker network inspect shared-dev-network --format="{{.Name}}: {{.IPAM.Config}}"
