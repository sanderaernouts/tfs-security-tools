# tfs-security-tools
A PowerShell module to extract TFS group membership information on different levels. The cmdlets in this module allow you to query TFS on different levels to eventually extract group and group membership information.

### Available PowerShell CmdLets
* Get-TeamProjectCollection
* Get-TeamProject
* Get-ApplicationGroup
* Get-GroupMember

##Instalation
###Dependencies
* Visual Studio Team Explorer 2013

###Steps
Go to https://github.com/sanderaernouts/tfs-security-tools/releases and download latest release of the TfsSecurityTools.zip archive. Unzip the archive and run the Install.ps1 script. This will place necesary files in your "%USERPROFILE%\Documents\WindowsPowerShell\Modules" folder.

##Uninstalation
Remove the TfsSecurityTools folder from the following location "%USERPROFILE%\Documents\WindowsPowerShell\Modules"

##Usage

Importing the module into your script:
```powershell
Import-Module -Name TfsSecurityTools
```

View available cmdlets:
```powershell
Get-Command -Module TfsSecurityTools
```

View help information per cmdlet:
```powershell
Get-Help Get-TeamProjectCollection
```

*note: you can use the -Detailed or -Full switch of the Get-Help cmdlet to more help information including examples*

View the full help documentation for all cmdlets in the module:
```powershell
Get-Command -Module TfsSecurityTools | Get-Help -Full
```

##Example
The example below will give you all members of all groups of all team projects in the collection "https://yourtfs.com/tfs/collection":
```powershell
Get-TeamProject "https://yourtfs.com/tfs/collection" | Get-ApplicationGroup | Get-GroupMember
```

The example below will give you only the valid users groups for all team projects in the collection "https://yourtfs.com/tfs/collection"
```powershell
Get-TeamProject "https://yourtfs.com/tfs/collection" | Get-ApplicationGroup -Name "*Valid User*"
```

The example below will give you all users (not groups) that are a member of the project administrator groups for all team projects in the collection "https://yourtfs.com/tfs/collection" and export this to a csv file.
```powershell
Get-TeamProject "https://yourtfs.com/tfs/collection" | Get-ApplicationGroup -Name "*Project Admin*" | Get-GroupMember -ExcludeGroups | Export-Csv "c:\tmp\export.csv"
```
*For more examples, see the help documentation of each individual cmdlet*
