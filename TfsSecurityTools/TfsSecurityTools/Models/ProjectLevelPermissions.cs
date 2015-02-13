using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TfsSecurityTools.Models
{
    public class ProjectLevelPermissions
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the project level permissions list.
        /// </summary>
        public List<Permission> ProjectLevelPermissionsList { get; set; }

        #endregion
    }
}
