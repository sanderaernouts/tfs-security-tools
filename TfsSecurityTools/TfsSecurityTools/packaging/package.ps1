Try{
	$packageDir = "$PSScriptRoot\..\published packages"
    $packagingDir = "$packageDir\TfsSecurityTools"
    #generate XML help file for module
	. "$PSScriptRoot\Helps.ps1"
	Import-Module $PSScriptRoot\..\TfsSecurityTools.psd1
    Convert-Helps $PSScriptRoot\..\TfsSecurityTools.dll-Help.ps1  $PSScriptRoot\..\TfsSecurityTools.dll-Help.xml -ErrorAction Stop
	Remove-Module TfsSecurityTools

    if(Test-Path $packageDir)
    {
        Remove-Item $packageDir -Force -Recurse | Out-Null
    }

	New-Item -ItemType Directory $packageDir | Out-Null
    New-Item -ItemType Directory $packagingDir | Out-Null
    
    #gather files in the module TfsSecurityTools folder
    Copy-Item $PSScriptRoot\..\TfsSecurityTools.psd1 -Destination $packagingDir
    Copy-Item $PSScriptRoot\..\TfsSecurityTools.dll -Destination $packagingDir
    Copy-Item $PSScriptRoot\..\TfsSecurityTools.dll-Help.xml -Destination $packagingDir
    Copy-Item $PSScriptRoot\..\Install.ps1 -Destination $packagingDir

	#clean the output folder
	#Get-ChildItem -File $PSScriptRoot\..\* | Remove-Item

	#create a zip package
	$zipFile = "$packageDir\TfsSecurityTools.zip"
	if(Test-Path "$PSScriptRoot\..\TfsSecurityTools.zip")
	{
		Get-ChildItem -File $zipFile | Remove-Item
	}
	Add-Type -Assembly System.IO.Compression.FileSystem
    $compressionLevel = [System.IO.Compression.CompressionLevel]::Optimal
    [System.IO.Compression.ZipFile]::CreateFromDirectory($packagingDir,$zipFile, $compressionLevel, $false)
}
Catch [system.exception] {
    Write-Error $_
	#force the build to fail on post build script error
    exit 1
}