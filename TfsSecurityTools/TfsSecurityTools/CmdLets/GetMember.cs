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
    [Cmdlet(VerbsCommon.Get, "GroupMember")]
    public class GetGroupMember : PSCmdlet
    {
        private string _collection;
        private string _guid;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ValueFromPipeline= true)]
        [Alias("CollectionUrl")]
        public string Collection
        {
            get { return _collection; }
            set { _collection = value; }
        }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true)]
        public string TeamFoundationId
        {
            get { return _guid; }
            set { _guid = value; }
        }

        protected override void ProcessRecord()
        {
            IEnumerable<MemberModel> members = MembershipExtractor.Extract(_collection, _guid);
            if (members != null)
                WriteObject(members, true);
        }
    }
}
