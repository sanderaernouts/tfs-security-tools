using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using TfsSecurityTools.Extractors;
using TfsSecurityTools.Models;

namespace TfsSecurityTools.CmdLets
{
    [Cmdlet(VerbsCommon.Get, "ApplicationGroup")]
    public class GetApplicationGroup : PSCmdlet
    {
        private string[] _project = new string[0];
        private string[] _name = new string[0];
        private string _collectionUrl;

        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        public string CollectionUrl
        {
            get { return _collectionUrl; }
            set { _collectionUrl = value; }
        }
        

        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("DisplayName", "ProjectDisplayName")]
        public string[] Project
        {
            get { return _project; }
            set { _project = value; }
        }

        [Parameter(Position = 2)]
        public string[] Name
        {
            get { return _name; }
            set { _name = value; }
        }
        protected override void ProcessRecord()
        {
            IEnumerable<ApplicationGroupDescriptor> groups = null;

            if (_project.Count() == 0)
                groups = ApplicationGroupExtractor.Extract(_collectionUrl, _name);
            else
            {
                foreach (string project in _project)
                {
                    groups = ApplicationGroupExtractor.Extract(_collectionUrl, _name, project);
                }
            }

            if (groups != null)
                WriteObject(groups, true);
        }
    }
}
