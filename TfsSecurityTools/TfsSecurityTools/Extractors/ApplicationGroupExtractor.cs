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

namespace TfsSecurityTools.Extractors
{
    public static class ApplicationGroupExtractor
    {
        public static IEnumerable<ApplicationGroupModel> Extract(string url, string name = null)
        {
            if (url == null)
                throw new ArgumentNullException("url");

            Uri uri = new Uri(url);

            TfsTeamProjectCollection collection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(uri);
            
            if(name==null)
            {
                return ExtractCollectionGroups(collection);

            }
            else
            {
                return ExtractProjectGroups(collection, name);
            }
        }

        private static IEnumerable<ApplicationGroupModel> ExtractCollectionGroups(TfsTeamProjectCollection collection)
        {
            return GetGroups(collection, collection.InstanceId.ToString());
        }

        private static IEnumerable<ApplicationGroupModel> ExtractProjectGroups(TfsTeamProjectCollection collection, string name)
        {
            var ims = collection.GetService<IIdentityManagementService>();
            var workItemStore = collection.GetService<WorkItemStore>();

            var project = workItemStore.Projects[name];

            return GetGroups(collection, project.Uri.AbsoluteUri);
        }

        private static IEnumerable<ApplicationGroupModel> GetGroups(TfsTeamProjectCollection collection, string scopeId)
        {
            var ims = collection.GetService<IIdentityManagementService>();
            TeamFoundationIdentity[] groups = ims.ListApplicationGroups(scopeId, Microsoft.TeamFoundation.Framework.Common.ReadIdentityOptions.None);
        
            return WrapGroups(collection.Uri.ToString(), groups);
        }

        private static IEnumerable<ApplicationGroupModel> WrapGroups(string collectionUrl, TeamFoundationIdentity[] groups)
        {
            return groups.Select(group => new ApplicationGroupModel()
                {
                    DisplayName = group.DisplayName,
                    TeamFoundationId = group.TeamFoundationId,
                    CollectionUrl = collectionUrl
                }).ToList();
        }
    }
}
