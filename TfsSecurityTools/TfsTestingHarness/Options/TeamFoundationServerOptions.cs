using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TfsTestingHarness.Options
{
    public class TeamFoundationServerOptions
    {
        public string Url { get; set; }

        public IEnumerable<TeamProjectCollectionOptions> Collections { get; set; }
    }
}
