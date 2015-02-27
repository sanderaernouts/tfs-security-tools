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
        private string[] _name = new string[0];

        
        private string _collection;

        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        public string Collection
        {
            get { return _collection; }
            set { _collection = value; }
        }
        

        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public string[] Name
        {
            get { return _name; }
            set { _name = value; }
        }
        protected override void ProcessRecord()
        {
            IEnumerable<ApplicationGroupModel> groups = null;

            if (_name.Count() == 0)
                groups = ApplicationGroupExtractor.Extract(_collection);
            else
            {
                foreach (string name in _name)
                {
                    groups = ApplicationGroupExtractor.Extract(_collection, name);
                }
            }

            if (groups != null)
                WriteObject(groups, true);
        }
    }
}
