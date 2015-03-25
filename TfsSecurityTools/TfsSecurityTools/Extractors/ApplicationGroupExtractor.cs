using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Framework.Client;
using Microsoft.TeamFoundation.Framework.Common;
using Microsoft.TeamFoundation.Server;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TfsSecurityTools.Models;
using TfsSecurityTools.Utils;

namespace TfsSecurityTools.Extractors
{
    public static class ApplicationGroupExtractor
    {
        public static IEnumerable<ApplicationGroupDescriptor> Extract(string url, string[] names, string project = null)
        {
            if (url == null)
                throw new ArgumentNullException("url");

            Uri uri = new Uri(url);

            TfsTeamProjectCollection collection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(uri);
            
            if(project==null)
            {
                return ExtractCollectionGroups(collection, names);

            }
            else
            {
                return ExtractProjectGroups(collection, project, names);
            }
        }

        private static IEnumerable<ApplicationGroupDescriptor> ExtractCollectionGroups(TfsTeamProjectCollection collection, string[] names = null)
        {
            TeamFoundationIdentity[] groups = GetGroups(collection, collection.InstanceId.ToString(), names);
            return WrapCollectionGroups(collection, groups);
        }

        private static IEnumerable<ApplicationGroupDescriptor> ExtractProjectGroups(TfsTeamProjectCollection collection, string project, string[] names = null )
        {
            var ims = collection.GetService<IIdentityManagementService>();
            var workItemStore = collection.GetService<WorkItemStore>();

            var teamProject = workItemStore.Projects[project];

            TeamFoundationIdentity[] groups = GetGroups(collection, teamProject.Uri.AbsoluteUri, names);

            return WrapProjectGroups(collection, teamProject, groups);
        }

        private static TeamFoundationIdentity[] GetGroups(TfsTeamProjectCollection collection, string scopeId, string[] names = null)
        {
            var ims = collection.GetService<IIdentityManagementService>();
            TeamFoundationIdentity[] groups = ims.ListApplicationGroups(scopeId, Microsoft.TeamFoundation.Framework.Common.ReadIdentityOptions.None);
        
            if(names != null && names.Count() > 0)
            {
                groups = FilterGroups(names, groups).ToArray();
            }

            return groups;
        }

        private static IEnumerable<TeamFoundationIdentity> FilterGroups(string[] names, TeamFoundationIdentity[] groups)
        {
            List<TeamFoundationIdentity> matchedGroups = new List<TeamFoundationIdentity>();
            
            foreach(TeamFoundationIdentity group in groups)
            {
                if (GlobMatcher.Match(names, group.DisplayName))
                    matchedGroups.Add(group);
            }

            return matchedGroups;
        }

        private static IEnumerable<ProjectCollectionApplicationGroupDescriptor> WrapCollectionGroups(TfsTeamProjectCollection collection, TeamFoundationIdentity[] groups)
        {
            return groups.Select(group => WrapCollectionGroup(collection, group)).ToList();
        }

        private static ProjectCollectionApplicationGroupDescriptor WrapCollectionGroup(TfsTeamProjectCollection collection, TeamFoundationIdentity group)
        {
            return new ProjectCollectionApplicationGroupDescriptor()
                {
                    DisplayName = group.DisplayName,
                    TeamFoundationId = group.TeamFoundationId,
                    CollectionDisplayName = collection.DisplayName,
                    CollectionUrl = collection.Uri.ToString()
                };
        }

        private static IEnumerable<ApplicationGroupDescriptor> WrapProjectGroups(TfsTeamProjectCollection collection, Project project, TeamFoundationIdentity[] groups)
        {
            return groups.Select(group => new ProjectApplicationGroupDescriptor()
            {
                DisplayName = group.DisplayName,
                TeamFoundationId = group.TeamFoundationId,
                ProjectDisplayName = project.Name,
                ProjectUri = project.Uri.AbsoluteUri.ToString(),
                CollectionDisplayName = collection.DisplayName,
                CollectionUrl = collection.Uri.ToString()
            }).ToList();
        }

    }
}
