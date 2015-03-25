using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TfsSecurityTools.Models
{
    public class ProjectDescriptor
    {
        public string DisplayName { get; set; }
        public string Uri { get; set; }
        public string CollectionDisplayName { get; set; }
        public string CollectionUrl { get; set; }
    }
}
