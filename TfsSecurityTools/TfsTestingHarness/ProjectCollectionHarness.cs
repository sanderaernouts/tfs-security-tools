using Microsoft.TeamFoundation.Client.Fakes;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TfsTestingHarness
{
    public class ProjectCollectionHarness
    {
        ShimTfsTeamProjectCollection _shim;
        WorkItemStoreHarness _workItemStore;
        //TestManagementServiceHarness _testManagementService;
        //VersionControlServerHarness _versionControlServer;
        public ShimTfsTeamProjectCollection Shim
        {
            get { return _shim; }
            set { _shim = value; }
        }

        //public TestManagementServiceHarness TestmanagementService { get { return _testManagementService; } }

        public WorkItemStoreHarness WorkItemStore { get { return _workItemStore; } }

        //public VersionControlServerHarness VersionControlServer { get { return _versionControlServer; } }

        public ProjectCollectionHarness(Uri collectionUri, params string[] teamProjects)
        {
            _workItemStore = new WorkItemStoreHarness(collectionUri, teamProjects);
            //_testManagementService = new TestManagementServiceHarness(_workItemStore.Project);
            //_versionControlServer = new VersionControlServerHarness();

            _shim = new ShimTfsTeamProjectCollection();
            _workItemStore.Shim.TeamProjectCollectionGet = () => _shim;

            ShimTfsConnection.AllInstances.GetServiceOf1<WorkItemStore>((t) => _workItemStore.Shim);
            //ShimTfsConnection.AllInstances.GetServiceOf1<VersionControlServer>((t) => _versionControlServer.Shim);
            ShimTfsTeamProjectCollectionFactory.GetTeamProjectCollectionUri = (uri) => _shim;
            ShimTfsConnection.AllInstances.UriGet = (x) => collectionUri;
        }
    }
}
