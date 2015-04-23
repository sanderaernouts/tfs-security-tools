using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using TfsSecurityTools.Extractors;

namespace TfsSecurityTools.CmdLets
{
    [Cmdlet(VerbsCommon.Get, "TeamProjectCollection")]
    public class GetProjectCollectionCmdLet : PSCmdlet
    {
        private string[] _urls;

        [Parameter(Mandatory=true, Position=0, ValueFromPipeline=true)]
        public string[] Url
        {
            get { return _urls; }
            set { _urls = value; }
        }

        protected override void ProcessRecord()
        {
            foreach (var url in _urls)
            {
                var collections = TeamProjectCollectionExtractor.Extract(url);
                WriteObject(collections, true);
            }
        }
    }
}
