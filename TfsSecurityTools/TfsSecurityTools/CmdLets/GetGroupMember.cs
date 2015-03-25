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
        private string _teamFoundationId;

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
            get { return _teamFoundationId; }
            set { _teamFoundationId = value; }
        }

        protected override void ProcessRecord()
        {       
            ApplicationGroup groupWithMembers = MembershipExtractor.Extract(_collection, _teamFoundationId);
            WriteObject(groupWithMembers, true);
        }
    }
}
