param([string] $name);

$NOVO_EXE = "$PSScriptRoot\$name.exe";
$ANT_EXE = "$PSScriptRoot\ProcessCellularBehavior.exe";
[IO.File]::Copy($ANT_EXE, $NOVO_EXE, $true);

Write-Host "Iniciando Processo Evolutivo de: $name";
Start-Process $NOVO_EXE;

Read-Host "Processo em Execução, tecle qualquer tecla para encerrar o processo...";
Get-Process | Where-Object {$_.Name.Contains($name)} | Stop-Process
