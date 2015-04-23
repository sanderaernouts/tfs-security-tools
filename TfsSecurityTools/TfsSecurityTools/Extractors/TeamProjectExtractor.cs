using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TfsSecurityTools.Models;
using TfsSecurityTools.Utils;

namespace TfsSecurityTools.Extractors
{
    public class TeamProjectExtractor
    {
        public static IEnumerable<ProjectDescriptor> Extract(string projectCollectionUrl, string[] names = null)
        {
            if(projectCollectionUrl == null)
                throw new ArgumentNullException("url");

            Uri uri = new Uri(projectCollectionUrl);
            TfsTeamProjectCollection tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(uri);

            WorkItemStore store = tfs.GetService<WorkItemStore>();

            List<ProjectDescriptor> descripors = WrapProjects(store.Projects);
            
            if(names !=null)
                return descripors.Where(x=> GlobMatcher.Match(names, x.DisplayName));
            return descripors;
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
