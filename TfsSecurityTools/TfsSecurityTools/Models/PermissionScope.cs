using System;
using System.Xml.Serialization;

namespace TfsSecurityTools.Models
{
    [Serializable]
    public enum PermissionScope
    {
        /// <summary>
        /// The team project.
        /// </summary>
        [XmlEnum(Name = "TeamProject")]
        TeamProject,

        /// <summary>
        /// The team build.
        /// </summary>
        [XmlEnum(Name = "TeamBuild")]
        TeamBuild,

        /// <summary>
        /// The work item areas.
        /// </summary>
        [XmlEnum(Name = "WorkItemAreas")]
        WorkItemAreas,

        /// <summary>
        /// The work item iterations.
        /// </summary>
        [XmlEnum(Name = "WorkItemIterations")]
        WorkItemIterations,

        /// <summary>
        /// The source control.
        /// </summary>
        [XmlEnum(Name = "SourceControl")]
        SourceControl,

        /// <summary>
        /// The Git source control.
        /// </summary>
        [XmlEnum(Name = "GitSourceControl")]
        GitSourceControl
    }
}
