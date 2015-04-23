using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TfsSecurityTools.Models
{
    public class MembershipDescriptor : TfsIdentityDescriptor
    {
        public string DisplayName { get; set; }

        public Guid TeamFoundationId { get; set; }

        public string Group { get; set; }
        public Guid GroupId { get; set; }
        public string Collection { get; set; }
        public string CollectionUrl { get; set; }
    }
}
