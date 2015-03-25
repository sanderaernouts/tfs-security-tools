using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Framework.Client;
using Microsoft.TeamFoundation.Framework.Common;
using Microsoft.TeamFoundation.Server;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TfsSecurityTools.Extractors;
using TfsSecurityTools.Models;

namespace TfsSecurityTools.QuickTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            string collectionUrl = "https://sandera.visualstudio.com/DefaultCollection";

            TfsTeamProjectCollection tfs =
                TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(collectionUrl));
            TfsConfigurationServer configurationServer =
                    TfsConfigurationServerFactory.GetConfigurationServer(new Uri("http://tfs-vm-13.cloudapp.net:8080/tfs"));

            ReadOnlyCollection<CatalogNode> projectNodes = configurationServer.CatalogNode.QueryChildren(
                    new[] { CatalogResourceTypes.TeamProject },
                    true, CatalogQueryOptions.None);
            
            ICommonStructureService css = tfs.GetService<ICommonStructureService>();
            var proj = css.GetProject("vstfs:///Classification/TeamProject/fd6fa263-b3f9-45e3-96af-ad67e75c9ff7");
            var node = css.GetNode("vstfs:///Classification/TeamProject/fd6fa263-b3f9-45e3-96af-ad67e75c9ff7");

            // Getting Identity Service
            var ims = tfs.GetService<IIdentityManagementService>();
            var workItemStore = tfs.GetService<WorkItemStore>();
            var server = tfs.GetService<ISecurityService>();

            List<TfsTeamProject> projects = new List<TfsTeamProject>();

            foreach(Project project in workItemStore.Projects)
            {
                var tfsTeamProject = ProjectPermissionExtractor.ExtractApplicationGroupPermissions(project, ims, server);
                projects.Add(tfsTeamProject);
            }

            PermissionsReport permissionsReport = new PermissionsReport()
            {
                TfsCollectionUrl = collectionUrl,
                TeamProjects = projects
            };

            ////Generate output file
            var fs = new FileStream(@"C:\Users\SanderA.CRONOS\Desktop\permissions.xml", FileMode.Create);
            var streamWriter = new StreamWriter(fs, Encoding.UTF8);

            using (streamWriter)
            {
                var xmlSerializer = new XmlSerializer(typeof(PermissionsReport));
                xmlSerializer.Serialize(streamWriter, permissionsReport);
                streamWriter.Flush();
            }
        }
    }
}
