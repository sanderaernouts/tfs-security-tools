using Microsoft.TeamFoundation.WorkItemTracking.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TfsTestingHarness
{
    public class WorkItemStoreHarness
    {
        private ShimWorkItemStore _shim;
        //private ProjectHarness _project;
        private ShimProjectCollection _projectCollection;
        private List<Project> _projects;
        //private List<WorkItem> _workItems;
        //private ShimWorkItemCollection _workItemCollection;
        //private ShimRegisteredLinkTypeCollection _registeredLinkTypeCollection;
        public ShimWorkItemStore Shim
        {
            get { return _shim; }
            set { _shim = value; }
        }

        public WorkItemStoreHarness(Uri teamProjectCollectionUri, params string[] teamProjects)
        {
            _shim = new ShimWorkItemStore();
            //_project = new ProjectHarness(teamProjectName, _shim);
            _projectCollection = new ShimProjectCollection();
            _projects = new List<Project>();

            //_workItems = new List<WorkItem>();
            //_workItemCollection = new ShimWorkItemCollection();
            //_workItemCollection.Bind(_workItems);

            //_registeredLinkTypeCollection = new ShimRegisteredLinkTypeCollection();
            //_registeredLinkTypeCollection.ItemGetString = x => new ShimRegisteredLinkType();

            foreach(string teamProject in teamProjects)
            {
                _projects.Add(ShimProject(teamProject, _shim, teamProjectCollectionUri));
            }

            _projectCollection.Bind(_projects);
            _shim.ProjectsGet = () => _projectCollection;
        }

        private ShimProject ShimProject(string name, WorkItemStore store, Uri collectionUri)
        {
            var uri = new Uri(String.Format("{0}/{1}", collectionUri.ToString(), name));
            var shim = new ShimProject();
            shim.NameGet = () => name;
            shim.StoreGet = () => store;
            shim.UriGet = () => uri;

            return shim;
        }
    }
}
