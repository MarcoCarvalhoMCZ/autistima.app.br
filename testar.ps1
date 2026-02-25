Param(
    [int]$Porta = 5000
)

Write-Host "Verificando processos na porta $Porta..."

# Localiza o PID dono da porta usando cmdlets nativos do Windows
$pid = Get-NetTCPConnection -LocalPort $Porta -ErrorAction SilentlyContinue |
    Select-Object -ExpandProperty OwningProcess -Unique

if ($pid) {
    Write-Host "Processo encontrado na porta $Porta (PID: $pid)"
    Write-Host "Finalizando processo..."
    try {
        Stop-Process -Id $pid -Force -ErrorAction Stop
        Start-Sleep -Seconds 1
        Write-Host "Porta $Porta liberada."
    }
    catch {
        Write-Warning "Não foi possível encerrar o processo $pid automaticamente. Execute este script em um PowerShell com privilégios de administrador ou finalize o processo manualmente."
        exit 1
    }
}
else {
    Write-Host "Porta $Porta já está livre"
}

Write-Host ""
Write-Host "Iniciando AUTistima..."
Write-Host "Acesse: http://localhost:$Porta"
Write-Host ""

# Vai para a pasta do projeto e executa a aplicação
Set-Location (Join-Path $PSScriptRoot "AUTistima")
# Confere se o dotnet está no PATH para evitar falha silenciosa
$dotnet = Get-Command dotnet -ErrorAction SilentlyContinue
if (-not $dotnet) {
    Write-Error "dotnet não encontrado no PATH. Abra um 'Developer PowerShell for VS' ou adicione o SDK do .NET ao PATH e tente novamente."
    exit 1
}

dotnet run --urls "http://localhost:$Porta"
