using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TfsTestingHarness.Options
{
    public class TeamProjectCollectionOptions
    {
        public string Name { get; set; }
        public string[] TeamProjects { get; set; }

        public TeamProjectCollectionOptions (string name, params string[] teamProjects)
        {
            Name = name;
            TeamProjects = teamProjects;
        }
    }
}
