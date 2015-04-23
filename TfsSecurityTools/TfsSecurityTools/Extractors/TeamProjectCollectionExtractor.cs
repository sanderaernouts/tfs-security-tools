using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Framework.Client;
using Microsoft.TeamFoundation.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TfsSecurityTools.Models;

namespace TfsSecurityTools.Extractors
{
    public class TeamProjectCollectionExtractor
    {
        public static ProjectCollectionDescriptor[] Extract(string url)
        {
            if (url == null)
                throw new ArgumentNullException("url");

            Uri tfsUri = new Uri(url);

            TfsConfigurationServer configurationServer =
                    TfsConfigurationServerFactory.GetConfigurationServer(tfsUri);


            ITeamProjectCollectionService tpcService = configurationServer.GetService<ITeamProjectCollectionService>();

            List<ProjectCollectionDescriptor> collections = new List<ProjectCollectionDescriptor>();

            foreach (TeamProjectCollection tpc in tpcService.GetCollections())
            {
                collections.Add(WrapProjectCollection(tpc, tfsUri));
            }

            return collections.ToArray();
        }


        private static ProjectCollectionDescriptor WrapProjectCollection(TeamProjectCollection collection, Uri baseUri)
        {
            string virtualDirectory = collection.VirtualDirectory.Replace("~", String.Empty);
            Uri collectionUri = new Uri(baseUri, virtualDirectory);
            return new ProjectCollectionDescriptor()
            {
                DisplayName = collection.Name,
                Url = ConstructCollectionUrl(baseUri, collection)
            };
        }

        private static string ConstructCollectionUrl(Uri baseUri, TeamProjectCollection collection)
        {
            string baseUrl = baseUri.ToString();
            //force a trailing slash to support URI combination further on
            if (!baseUrl.EndsWith("/"))
            {
                baseUrl = baseUrl + "/";
            }

            string collectionDirectory = collection.VirtualDirectory.Replace("~/", String.Empty);

            return baseUrl + collectionDirectory;
        }
    }
}
