using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TfsSecurityTools.Models
{
    public class ApplicationGroupDescriptor
    {
        public string DisplayName { get; set; }
        public Guid TeamFoundationId { get; set; }
        public string CollectionDisplayName { get; set; }
        public string CollectionUrl { get; set; }
    }
}
