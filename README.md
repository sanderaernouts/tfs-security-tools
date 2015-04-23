# tfs-security-tools
A PowerShell module to extract TFS group membership information on different levels. The cmdlets in this module allow you to query TFS on different levels to eventually extract group and group membership information.

### Available PowerShell CmdLets
* Get-TeamProjectCollection
* Get-TeamProject
* Get-ApplicationGroup
* Get-GroupMember

##Instalation

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
The example below will give you all members of all groups of all team projects in the collection "https//yourtfs.com/tfs/collection":
```powershell
Get-TeamProject "https//yourtfs.com/tfs/collection" | Get-ApplicationGroup | Get-GroupMember
```
