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
        public static IEnumerable<MemberModel> Extract(string url, string id)
        {
            if (url == null)
                throw new ArgumentNullException("url");

            Uri uri = new Uri(url);

            TfsTeamProjectCollection collection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(uri);

            var ims = collection.GetService<IIdentityManagementService>();
            Guid [] guids = new Guid[1] {new Guid(id)};
            TeamFoundationIdentity[] identies = ims.ReadIdentities(guids, MembershipQuery.Expanded);
            List<MemberModel> membership = new List<MemberModel>();

            foreach(TeamFoundationIdentity identity in identies)
            {
                foreach (IdentityDescriptor member in identity.Members)
                {
                    TeamFoundationIdentity i = ims.ReadIdentity(member, MembershipQuery.None, ReadIdentityOptions.ExtendedProperties);
                    membership.Add(new MemberModel() { DisplayName = i.DisplayName, TeamFoundationId = i.TeamFoundationId, CollectionUrl = url });
                }
            }

            return membership;
        }
    }
}
