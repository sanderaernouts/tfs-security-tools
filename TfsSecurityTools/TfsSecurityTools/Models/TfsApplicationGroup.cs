using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TfsSecurityTools.Models
{
    [XmlRoot(ElementName = "Group")]
    public class TfsApplicationGroup
    {
        public string Name { get; set; }
        public string TeamProject { get; set; }

        [XmlElement(ElementName = "ProjectLevelPermissions")]
        public ProjectLevelPermissions ProjectPermissions { get; set; }
    }
}
