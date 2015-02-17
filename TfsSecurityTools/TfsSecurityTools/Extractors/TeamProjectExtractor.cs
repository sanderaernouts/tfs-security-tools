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
        public static List<TeamProjectModel> Extract(string projectCollectionUrl)
        {
            if(projectCollectionUrl == null)
                throw new ArgumentNullException("url");

            Uri uri = new Uri(projectCollectionUrl);
            TfsTeamProjectCollection tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(uri);

            WorkItemStore store = tfs.GetService<WorkItemStore>();

            return WrapProjects(store.Projects);
        }

        private static List<TeamProjectModel> WrapProjects (ProjectCollection projects)
        {
            List<TeamProjectModel> projectModels = new List<TeamProjectModel>();
            foreach (Project project in projects)
                projectModels.Add(WrapProject(project));
            return projectModels;
        }

        private static TeamProjectModel WrapProject (Project project)
        {
            return new TeamProjectModel()
            {
                Name = project.Name,
                Collection = project.Store.TeamProjectCollection.Uri.ToString(),
                Url = project.Uri.ToString()
            };
        }
    }
}
