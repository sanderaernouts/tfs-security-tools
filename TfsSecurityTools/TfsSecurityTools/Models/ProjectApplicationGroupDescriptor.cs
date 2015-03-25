using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TfsSecurityTools.Models
{
    public class ProjectApplicationGroupDescriptor : ProjectCollectionApplicationGroupDescriptor
    {
        public string ProjectDisplayName { get; set; }
        public string ProjectUrl { get; set; }
        public string ProjectUri { get; set; }
    }
}
