using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.TeamFoundation.Client.Fakes;
using Microsoft.TeamFoundation.Framework.Client;
using Microsoft.TeamFoundation.Framework.Client.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TfsTestingHarness.Options;

namespace TfsTestingHarness
{
    public class TeamFoundationServerHarness : IDisposable
    {
        private List<ProjectCollectionHarness> _projectCollections;
        private IDisposable _context;
        public IList<ProjectCollectionHarness> ProjectCollections { get { return _projectCollections; } }

        public TeamFoundationServerHarness()
            : this("TeamFoundationServerHarnessProject")
        {

        }
        public TeamFoundationServerHarness(string projectCollectionUrl, params string[] teamProjects)
        {
            _context = ShimsContext.Create();
            _projectCollections = new List<ProjectCollectionHarness>(){ new ProjectCollectionHarness(new Uri(projectCollectionUrl), teamProjects)};
        }

        public TeamFoundationServerHarness(TeamFoundationServerOptions options)
        {
            _context = ShimsContext.Create();

            foreach(var collection in options.Collections)
            {
                Uri collectionUri = new Uri(String.Format("{0}/{1}", options.Url, collection.Name));
                var harness = new ProjectCollectionHarness(collectionUri, collection.TeamProjects.ToArray());
                _projectCollections.Add(harness);
            }

            
            StubITeamProjectCollectionService stub = new StubITeamProjectCollectionService();
            stub.GetCollections = () => _projectCollections.Select(x => x.Shim).OfType<TeamProjectCollection>().ToList();
            ShimTfsConnection.AllInstances.GetServiceOf1<ITeamProjectCollectionService>((t) => stub);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
