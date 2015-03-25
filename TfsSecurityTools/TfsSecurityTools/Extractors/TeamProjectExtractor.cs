using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TfsSecurityTools.Models;

namespace TfsSecurityTools.Extractors
{
    public class TeamProjectExtractor
    {
        public static List<ProjectDescriptor> Extract(string projectCollectionUrl)
        {
            if(projectCollectionUrl == null)
                throw new ArgumentNullException("url");

            Uri uri = new Uri(projectCollectionUrl);
            TfsTeamProjectCollection tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(uri);

            WorkItemStore store = tfs.GetService<WorkItemStore>();

            return WrapProjects(store.Projects);
        }

        private static List<ProjectDescriptor> WrapProjects(ProjectCollection projects)
        {
            List<ProjectDescriptor> projectModels = new List<ProjectDescriptor>();
            foreach (Project project in projects)
                projectModels.Add(WrapProject(project));
            return projectModels;
        }

        private static ProjectDescriptor WrapProject(Project project)
        {
            TfsTeamProjectCollection collection = project.Store.TeamProjectCollection;
            return new ProjectDescriptor()
            {
                DisplayName = project.Name,
                Uri = project.Uri.AbsoluteUri,
                CollectionDisplayName = collection.DisplayName,
                CollectionUrl = collection.Uri.ToString()
            };
        }
    }
}
