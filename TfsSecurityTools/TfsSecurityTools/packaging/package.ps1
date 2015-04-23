Try{
    $packagingDir = "$PSScriptRoot\..\TfsSecurityTools"
    #generate XML help file for module
	. Helps.ps1
	Import-Module $PSScriptRoot\..\TfsSecurityTools.psd1
    Convert-Helps $PSScriptRoot\..\TfsSecurityTools.dll-Help.ps1  $PSScriptRoot\..\TfsSecurityTools.dll-Help.xml -ErrorAction Stop
	Remove-Module TfsSecurityTools

    if(Test-Path $packagingDir)
    {
        Remove-Item $packagingDir -Force -Recurse | Out-Null
    }

    New-Item -ItemType Directory $packagingDir | Out-Null
    
    #gather files in the module TfsSecurityTools folder
    Move-Item $PSScriptRoot\..\TfsSecurityTools.psd1 -Destination $packagingDir
    Move-Item $PSScriptRoot\..\TfsSecurityTools.dll -Destination $packagingDir
    Move-Item $PSScriptRoot\..\TfsSecurityTools.dll-Help.xml -Destination $packagingDir
    Move-Item $PSScriptRoot\..\Install.ps1 -Destination $packagingDir

	#clean the output folder
	Get-ChildItem -File $PSScriptRoot\..\* | Remove-Item

	#create a zip package
	Add-Type -Assembly System.IO.Compression.FileSystem
    $compressionLevel = [System.IO.Compression.CompressionLevel]::Optimal
    [System.IO.Compression.ZipFile]::CreateFromDirectory($packagingDir,"$PSScriptRoot\..\TfsSecurityTools.zip", $compressionLevel, $false)
}
Catch [system.exception] {
    Write-Error $_
	#force the build to fail on post build script error
    exit 1
}