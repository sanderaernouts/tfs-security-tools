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
        private string[] _projectCollectionUrl;

        [Parameter(Mandatory=true, Position=1, ValueFromPipelineByPropertyName=true)]
        public string[] ProjectCollectionUrl
        {
            get { return _projectCollectionUrl; }
            set { _projectCollectionUrl = value; }
        }


        protected override void ProcessRecord()
        {
            foreach (var url in _projectCollectionUrl)
            {
                var projects = TeamProjectExtractor.Extract(url);
                foreach (var project in projects)
                    WriteObject(project);
            }
        }
    }
}
