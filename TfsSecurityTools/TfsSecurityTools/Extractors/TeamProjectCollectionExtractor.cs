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
        public static IList<ProjectCollectionDescriptor> Extract(string url)
        {
            if (url == null)
                throw new ArgumentNullException("url");
            
            Uri uri = new Uri(url);

            TfsConfigurationServer configurationServer =
                    TfsConfigurationServerFactory.GetConfigurationServer(uri);


            ITeamProjectCollectionService tpcService = configurationServer.GetService<ITeamProjectCollectionService>();
            
            /*
            foreach (TeamProjectCollection tpc in tpcService.GetCollections())
            {
                
            }
            */

            throw new NotImplementedException();
        }
    }
}
