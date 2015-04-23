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
    [Cmdlet(VerbsCommon.Get, "TeamProject")]
    public class GetTeamProjectCmdLet : PSCmdlet
    {
        private string _projectCollectionUrl;
        private string[] _name = null;

        [Parameter(Mandatory=true, Position=1, ValueFromPipelineByPropertyName=true)]
        public string ProjectCollectionUrl
        {
            get { return _projectCollectionUrl; }
            set { _projectCollectionUrl = value; }
        }

        [Parameter(Mandatory=false, Position=2) ]
        public string[] Name
        {
            get{return _name;}
            set{_name = value;}
        }

        protected override void ProcessRecord()
        {
            var projects = TeamProjectExtractor.Extract(_projectCollectionUrl, _name);
            WriteObject(projects, true);
        }
    }
}
