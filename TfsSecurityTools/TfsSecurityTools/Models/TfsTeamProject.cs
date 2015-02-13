using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TfsSecurityTools.Models
{
    public class TfsTeamProject
    {

        public string Name { get; set; }
        [XmlArray(ElementName="ApplicationGroups")]
        [XmlArrayItem(ElementName="ApplicationGroup")]
        public List<TfsApplicationGroup> ApplicationGroups { get; set; }
    }
}
