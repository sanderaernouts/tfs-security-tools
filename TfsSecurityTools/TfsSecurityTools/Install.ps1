$personalModules = "$HOME\Documents\WindowsPowerShell\Modules\"
$modulePath = "$personalModules\TfsSecurityTools"

if((Test-Path $modulePath) -ne $true)
{
    New-Item -ItemType Directory -Path $modulePath
}

#Remove the module if it is loaded
Get-Module | Where-Object {$_.name -eq "TfsSecurityTools"} | Remove-Module -Force

Copy-Item .\TfsSecurityTools.dll -Destination $modulePath
Copy-Item .\TfsSecurityTools.psd1 -Destination $modulePath