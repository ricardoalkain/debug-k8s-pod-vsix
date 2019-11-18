param(
    [Parameter(Mandatory=$true)][string]$app,
    [string]$pod,
    [switch]$swagger
)

Write-Host "Automated Kubernetes Debugging script"
Write-Host "-------------------------------------------------------------`n"

Write-Host "Checking kubectl..."
if ($null -eq (Get-Command "kubectl.exe" -ErrorAction SilentlyContinue))
{
   Write-Error 'Kubernetes/Minikube is not properly installed on this machine: "kubectl.exe" not found in the system path.'
   exit 1
}

if ($null -eq $pod)
{
    Write-Host "\nSearching POD for '$app'..."
    $pod = kubectl get pods --selector="app=$app" -o jsonpath='{.items[0].metadata.name}'
    Write-Host "  - POD found: $pod"
}

# TODO: Get external IP before invoke Swagger interface
if ($swagger)
{
    Write-Host "\nSearching service port for '$app'..."
    $port = kubectl get svc --selector="app=$app" -o jsonpath='{.items[0].spec.ports[0].port}'
    if ($port -eq 0) {
        Write-Host "Port number for application '$app' not found. Unable to open Swagger interface."
    }
    else
    {
        Write-Host "\nConfiguring port-forwarding for port $port...";
        start-process -FilePath "kubectl.exe" -ArgumentList "port-forward","$pod","${port}:$port"
        Start-Process "http://localhost:$port/swagger"
    }
}

Write-Host '\nPreparing to install VSDBG...';
kubectl exec $pod -i `-- apt-get update;
kubectl exec $pod -i `-- apt-get install -y --no-install-recommends unzip
kubectl exec $pod -i `-- curl -sSL https://aka.ms/getvsdbgsh -o '/root/getvsdbg.sh'

Write-Host "\nInstalling VSDBG inside POD $pod..."
kubectl exec $pod -i `-- bash /root/getvsdbg.sh -v latest -l /vsdbg

$exe = 'dotnet'
Write-Host "\nSeaching for $exe process PID inside POD..."
$prid = [int](kubectl exec $pod -i `-- pidof -s $exe)

if ($prid -eq 0) {
    Write-Error "No .NET Core application running in POD '$pod'."
    exit 2
}

Write-Host "\nAttaching debugger to process $prid..."
kubectl exec $pod -i `-- /vsdbg/vsdbg --interpreter=mi --attach $prid