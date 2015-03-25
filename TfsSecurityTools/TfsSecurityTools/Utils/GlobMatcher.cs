using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minimatch;

namespace TfsSecurityTools.Utils
{
    public static class GlobMatcher
    {
        public static bool Match(string globPattern, string input)
        {
            return Minimatcher.Check(input, globPattern);
        }

        public static bool Match(string[] globPatterns, string input)
        {
            foreach(string globPattern in globPatterns)
            {
                if (Match(globPattern, input))
                    return true;
            }

            return false;
        }
    }
}
