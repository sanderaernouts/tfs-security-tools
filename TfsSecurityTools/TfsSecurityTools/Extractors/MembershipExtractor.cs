using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Framework.Client;
using Microsoft.TeamFoundation.Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TfsSecurityTools.Models;
using TfsSecurityTools.Utils;

namespace TfsSecurityTools.Extractors
{
    public class MembershipExtractor
    {
        public static MembershipDescriptor[] Extract(string url, string id, bool excludeGroups, bool excludeUsers, string[] _name=null)
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

            IdentityDescriptor[] members = group.Members;
            int totalMembers = members.Count();

            List<MembershipDescriptor> descriptors = new List<MembershipDescriptor>();

            for (int i = 0; i < totalMembers; i++)
            {
                TeamFoundationIdentity member = ims.ReadIdentity(members[i], MembershipQuery.None, ReadIdentityOptions.ExtendedProperties);
                //if name patterns are past and there is no match, skip the identity
                if (_name != null && !GlobMatcher.Match(_name, member.DisplayName))
                    continue;

                //if identity is an container, a group, and we want to exclude groups, skip the identity
                if (member.IsContainer && excludeGroups)
                    continue;

                //if identity is not an container, a useraccount, and we want to exclude users, skip the identity
                if (!member.IsContainer && excludeUsers)
                    continue;
                MembershipDescriptor descriptor = WrapMembership(collection, group, member);
                descriptors.Add(descriptor);
            }

            return descriptors.ToArray();
        }

        private static MembershipDescriptor WrapMembership(TfsTeamProjectCollection collection, TeamFoundationIdentity group, TeamFoundationIdentity member)
        {
            return new MembershipDescriptor()
            {
                DisplayName = member.DisplayName,
                TeamFoundationId = member.TeamFoundationId,
                Collection = collection.DisplayName,
                CollectionUrl = collection.Uri.ToString(),
                Group = group.DisplayName,
                GroupId = group.TeamFoundationId
            };
        }
    }
}
