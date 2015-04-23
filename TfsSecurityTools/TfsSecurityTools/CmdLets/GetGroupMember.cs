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
        private string[] _name = null;
        private bool _excludeGroups;
        private bool _excludeUsers;

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

        [Parameter(Mandatory=false, Position=3)]
        public string[] Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [Parameter(Mandatory = false, Position = 4)]
        public SwitchParameter ExcludeGroups
        {
            get { return _excludeGroups; }
            set { _excludeGroups = value; }
        }

        [Parameter(Mandatory = false, Position = 5)]
        public SwitchParameter ExcludeUsers
        {
            get { return _excludeUsers; }
            set { _excludeUsers = value; }
        }

        protected override void ProcessRecord()
        {       
            MembershipDescriptor[] members = MembershipExtractor.Extract(_collection, _teamFoundationId, _excludeGroups, _excludeUsers, _name);
            WriteObject(members, true);
        }
    }
}
