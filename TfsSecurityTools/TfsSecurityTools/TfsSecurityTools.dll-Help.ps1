
# Get-GroupMember command help
@{
	command = 'Get-GroupMember'
	synopsis = 'Gets the group members for specific TFS application group'
	description = ''
	parameters = @{
		Collection = ''
		ExcludeGroups = ''
		ExcludeUsers = ''
		Name = ''
		TeamFoundationId = ''
	}
	inputs = @(
		@{
			type = ''
			description = ''
		}
	)
	outputs = @(
		@{
			type = ''
			description = ''
		}
	)
	notes = ''
	examples = @(
		@{
			#title = ''
			#introduction = ''
			code = {
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
		Name = ''
		ProjectCollectionUrl = ''
	}
	inputs = @(
		@{
			type = ''
			description = ''
		}
	)
	outputs = @(
		@{
			type = ''
			description = ''
		}
	)
	notes = ''
	examples = @(
		@{
			#title = ''
			#introduction = ''
			code = {
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
	synopsis = 'Gets the team project collections for the specified TFS server'
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
			type = ''
			description = ''
		}
	)
	notes = ''
	examples = @(
		@{
			#title = ''
			#introduction = ''
			code = {
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
		CollectionUrl = ''
		Name = ''
		Project = ''
	}
	inputs = @(
		@{
			type = ''
			description = ''
		}
	)
	outputs = @(
		@{
			type = ''
			description = ''
		}
	)
	notes = ''
	examples = @(
		@{
			#title = ''
			#introduction = ''
			code = {
			}
			remarks = ''
			test = { . $args[0] }
		}
	)
	links = @(
		@{ text = ''; URI = '' }
	)
}
