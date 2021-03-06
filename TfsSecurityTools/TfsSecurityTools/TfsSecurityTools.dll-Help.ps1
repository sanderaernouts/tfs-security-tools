
# Get-GroupMember command help
@{
	command = 'Get-GroupMember'
	synopsis = 'Gets the group members for specific TFS application group'
	description = 'Retrieves the group members for a specfic TFS application group based on the ID and collection. Users or Groups can be excluded as members and members can be filtered by name using a GLOB pattern'
	parameters = @{
		Collection = 'The url of the team project collection the group belongs to'
		ExcludeGroups = 'Switch to exclude groups which are a member of the specified application group'
		ExcludeUsers = 'Switch to exclude users which are a member of the specified application group'
		Name = 'The name of the member(s) to retrieve, supports GLOB pattterns'
		TeamFoundationId = 'The TeamFoundationId of the application group from which the members must be retrieved'
	}
	inputs = @(
		@{
			type = 'TfsSecurityTools.Models.ApplicationGroupDescriptor'
			description = 'descriptor of a TFS application group, can be piped into this commandlet'
		}
	)
	outputs = @(
		@{
			type = 'TfsSecurityTools.Models.MemberShipDescriptor'
			description = 'descriptor of the group membership, can be exported to CSV'
		}
	)
	notes = ''
	examples = @(
		@{
			title = 'Get all members of all groups on all team projects in a specific team project collection'
			#introduction = 'Multiple commands can be used in the pipeline to pipe the desired information into this cmdlet'
			code = {
				Get-TeamProject "https://your-tfs.server/tfs/your-collection" | Get-ApplicationGroup | Get-GroupMember
			}
			remarks = ''
			test = { . $args[0] }
		}
	)
	links = @(
		@{ text = ''; URI = '' }
	)
}

# Get-TeamProject command help
@{
	command = 'Get-TeamProject'
	synopsis = 'Gets the team projects for a specific team project collections'
	description = ''
	parameters = @{
		Name = 'The name of the project to retrieve, supports GLOB patterns'
		CollectionUrl = 'URL of the project collection to retrieve the projects from'
	}
	inputs = @(
		@{
			type = ''
			description = ''
		}
	)
	outputs = @(
		@{
			type = 'TfsSecurityTools.Models.ProjectDescriptor'
			description = 'Descriptor for a project, can be piped into the Get-ApplicationGroup cmdlet'
		}
	)
	notes = ''
	examples = @(
		@{
			title = 'Get all projects from a project collection'
			#introduction = ''
			code = {
				Get-TeamProject "https://your-tfs.server/tfs/your-collection"
			}
			remarks = ''
			test = { . $args[0] }
		}
	)
	links = @(
		@{ text = ''; URI = '' }
	)
}

# Get-TeamProjectCollection command help
@{
	command = 'Get-TeamProjectCollection'
	synopsis = 'Gets the team project collections for the specified TFS server, you need the Edit instance-level information to run this command'
	description = ''
	parameters = @{
		Url = ''
	}
	inputs = @(
		@{
			type = ''
			description = ''
		}
	)
	outputs = @(	
		@{
			type = 'TfsSecurityTools.Models.ProjectCollectionDescriptor'
			description = 'Descriptor for a project collection, can be piped into the Get-TeamProject or Get-ApplicationGroup cmdlets'
		}
	)
	notes = ''
	examples = @(
		@{
			title = 'Get all project collections from a tfs server'
			#introduction = ''
			code = {
				Get-TeamProjectCollection "https://your-tfs.server/tfs/your-collection"
			}
			remarks = ''
			test = { . $args[0] }
		}
	)
	links = @(
		@{ text = ''; URI = '' }
	)
}

# Get-ApplicationGroup command help
@{
	command = 'Get-ApplicationGroup'
	synopsis = 'Gets the TFS application group for the specified project or collection'
	description = ''
	parameters = @{
		CollectionUrl = 'URL of the team project collection the application group belongs to'
		Name = 'Name of the application group to retrieve, supports GLOB patterns'
		Project = 'Optional name of the project to specify the project to retrieve the groups from'
	}
	inputs = @(
		@{
			type = 'TfsSecurityTools.Models.ProjectCollectionDescriptor'
			description = 'Descriptor for a project collection, can be piped into this commandlet to get all applications groups on collection level'
		},
		@{
			type = 'TfsSecurityTools.Models.ProjectDescriptor'
			description = 'Descriptor for a project, can be piped into this commandlet to get all applications groups on project level'
		}
	)
	outputs = @(
		@{
			type = 'TfsSecurityTools.Models.ApplicationGroupDescriptor'
			description = 'descriptor of a TFS application group, can be piped into this commandlet'
		}
	)
	notes = ''
	examples = @(
		@{
			title = 'Get all application groups on project collection level'
			#introduction = ''
			code = {
				Get-ApplicationGroup -CollectionUrl "https://your-tfs.server/tfs/your-collection"
			}
			remarks = ''
			test = { . $args[0] }
		},
		@{
			title = 'Get all application groups on project level'
			#introduction = ''
			code = {
				Get-ApplicationGroup -CollectionUrl "https://your-tfs.server/tfs/your-collection" -Project "YourProject"
			}
			remarks = ''
			test = { . $args[0] }
		},
		@{
				title = 'Get only groups that contain the word "Valid" (on project level)'
				#introduction = ''
				code = {
					Get-ApplicationGroup -CollectionUrl "https://your-tfs.server/tfs/your-collection" -Project "YourProject" -Name "*Valid*"
				}
				remarks = ''
				test = { . $args[0] }
		},
		@{
				title = 'Get all groups on all projects within a collection'
				#introduction = ''
				code = {
					Get-TeamProject "https://your-tfs.server/tfs/your-collection" | Get-ApplicationGroup
				}
				remarks = ''
				test = { . $args[0] }
		}
	)
	links = @(
		@{ text = ''; URI = '' }
	)
}
