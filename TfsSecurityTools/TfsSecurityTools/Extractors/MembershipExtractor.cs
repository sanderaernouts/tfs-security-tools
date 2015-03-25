using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Framework.Client;
using Microsoft.TeamFoundation.Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TfsSecurityTools.Models;

namespace TfsSecurityTools.Extractors
{
    public class MembershipExtractor
    {
        public static ApplicationGroup Extract(string url, string id)
        {
            if (url == null)
                throw new ArgumentNullException("url");

            Guid groupGuid = new Guid(id);

            Uri uri = new Uri(url);

            TfsTeamProjectCollection collection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(uri);

            var ims = collection.GetService<IIdentityManagementService>();
            Guid[] guids = new Guid[1] { groupGuid };
            TeamFoundationIdentity[] identies = ims.ReadIdentities(guids, MembershipQuery.Expanded);
            TeamFoundationIdentity group = identies.First();

            List<TfsIdentityDescriptor> membership = new List<TfsIdentityDescriptor>();

            foreach (IdentityDescriptor member in group.Members)
            {
                TeamFoundationIdentity i = ims.ReadIdentity(member, MembershipQuery.None, ReadIdentityOptions.ExtendedProperties);
                membership.Add(new TfsIdentityDescriptor() { DisplayName = i.DisplayName, TeamFoundationId = i.TeamFoundationId });
            }

            return new ApplicationGroup()
            {
                DisplayName = group.DisplayName,
                TeamFoundationId = Guid.Parse(id),
                Members = membership.ToArray()
            };
            
        }
    }
}
