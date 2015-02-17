using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace TfsSecurityTools.CmdLets
{
    [Cmdlet(VerbsCommon.Get, "ApplicationGroup")]
    public class GetApplicationGroup : PSCmdlet
    {
        private string[] _name;

        
        private string[] _collection;

        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        public string[] Collection
        {
            get { return _collection; }
            set { _collection = value; }
        }
        

        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        public string[] Name
        {
            get { return _name; }
            set { _name = value; }
        }
        protected override void ProcessRecord()
        {
            WriteObject(_name);
            WriteObject(_collection);
        }
    }
}
