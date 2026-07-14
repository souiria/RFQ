
# (docker ps -q | ForEach-Object { docker inspect $_ --format '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}} {{ .Name }}' }).replace('/','')

$containers=(docker ps -q)
ForEach($container in $containers) {
    $containerName = (docker inspect $container --format '{{.Name}}').replace('/','')
    $containerIP = (docker inspect $container --format '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}')
    $containerPorts = (docker port $container)
    Write-Host "Container: $containerName, IP: $containerIP, Ports: $containerPorts"
}
