using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TfsSecurityTools.Utils
{
    public static class PermissionFlags
    {
        #region EnumrationsList

        /// <summary>
        ///     Authorization Catalog Service Permissions
        /// </summary>
        [Flags]
        public enum AuthorizationCssNodePermissions
        {
            /// <summary>
            ///     The none.
            /// </summary>
            None = 0x0,

            /// <summary>
            ///     The generic read.
            /// </summary>
            GenericRead = 0x1,

            /// <summary>
            ///     The generic write.
            /// </summary>
            GenericWrite = 0x2,

            /// <summary>
            ///     The create children.
            /// </summary>
            CreateChildren = 0x4,

            /// <summary>
            ///     The delete.
            /// </summary>
            Delete = 0x8,

            /// <summary>
            ///     The work item read.
            /// </summary>
            WorkItemRead = 0x10,

            /// <summary>
            ///     The work item write.
            /// </summary>
            WorkItemWrite = 0x20,

            /// <summary>
            ///     The manage test plans.
            /// </summary>
            ManageTestPlans = 0x40,

            /// <summary>
            ///     The all permissions.
            /// </summary>
            AllPermissions = 0x1BFF // s
        }

        /// <summary>
        ///     The authorization iteration node permissions.
        /// </summary>
        [Flags]
        public enum AuthorizationIterationNodePermissions
        {
            /// <summary>
            ///     The none.
            /// </summary>
            None = 0x0,

            /// <summary>
            ///     The generic read.
            /// </summary>
            GenericRead = 0x1,

            /// <summary>
            ///     The generic write.
            /// </summary>
            GenericWrite = 0x2,

            /// <summary>
            ///     The create children.
            /// </summary>
            CreateChildren = 0x4,

            /// <summary>
            ///     The delete.
            /// </summary>
            Delete = 0x8,

            /// <summary>
            ///     The all permissions.
            /// </summary>
            AllPermissions = 0x1BFF // s
        }

        /// <summary>
        ///     The authorization project permissions.
        /// </summary>
        [Flags]
        public enum AuthorizationProjectPermissions
        {
            // derived from Microsoft.TeamFoundation.Server.AuthorizationProjectPermissions, Microsoft.TeamFoundation, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a

            /// <summary>
            ///     The none.
            /// </summary>
            None = 0x0,

            /// <summary>
            ///     The generic read.
            /// </summary>
            GenericRead = 0x1,

            /// <summary>
            ///     The generic write.
            /// </summary>
            GenericWrite = 0x2,

            /// <summary>
            ///     The delete.
            /// </summary>
            Delete = 0x4,

            /// <summary>
            ///     The publish test results.
            /// </summary>
            PublishTestResults = 0x8,

            /// <summary>
            ///     The administer build.
            /// </summary>
            AdministerBuild = 0x10,

            /// <summary>
            ///     The start build.
            /// </summary>
            StartBuild = 0x20,

            /// <summary>
            ///     The edit build status.
            /// </summary>
            EditBuildStatus = 0x40,

            /// <summary>
            ///     The update build.
            /// </summary>
            UpdateBuild = 0x80,

            /// <summary>
            ///     The delete test results.
            /// </summary>
            DeleteTestResults = 0x100,

            /// <summary>
            ///     The view test results.
            /// </summary>
            ViewTestResults = 0x200,

            /// <summary>
            ///     The manage test environments.
            /// </summary>
            ManageTestEnvironments = 0x800,

            /// <summary>
            ///     The manage test configurations.
            /// </summary>
            ManageTestConfigurations = 0x1000,

            /// <summary>
            ///     The all permissions.
            /// </summary>
            AllPermissions = 0x1BFF
        }

        /// <summary>
        /// Git Version Control Permissions
        /// </summary>
        [Flags]
        public enum GitPermissions
        {

            /// <summary>
            /// The none
            /// </summary>
            None = 0x0,
            /// <summary>
            /// The administer
            /// </summary>
            Administer = 0x1,
            /// <summary>
            /// The generic read
            /// </summary>
            GenericRead = 0x2,
            /// <summary>
            /// The generic contribute
            /// </summary>
            GenericContribute = 0x4,
            /// <summary>
            /// The force push
            /// </summary>
            ForcePush = 0x8,
            /// <summary>
            /// The create branch
            /// </summary>
            CreateBranch = 0x10,
            /// <summary>
            /// The create tag
            /// </summary>
            CreateTag = 0x20,
            /// <summary>
            /// The manage note
            /// </summary>
            ManageNote = 0x40
        }

        /// <summary>
        ///     The build permissions.
        /// </summary>
        [Flags]
        public enum BuildPermissions
        {
            // derived from Microsoft.TeamFoundation.Build.Common.BuildPermissions, Microsoft.TeamFoundation.Build.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a

            /// <summary>
            ///     The none.
            /// </summary>
            None = 0x0,

            /// <summary>
            ///     The view builds.
            /// </summary>
            ViewBuilds = 0x1,

            /// <summary>
            ///     The edit build quality.
            /// </summary>
            EditBuildQuality = 0x2,

            /// <summary>
            ///     The retain indefinitely.
            /// </summary>
            RetainIndefinitely = 0x4,

            /// <summary>
            ///     The delete builds.
            /// </summary>
            DeleteBuilds = 0x8,

            /// <summary>
            ///     The manage build qualities.
            /// </summary>
            ManageBuildQualities = 0x10,

            /// <summary>
            ///     The destroy builds.
            /// </summary>
            DestroyBuilds = 0x20,

            /// <summary>
            ///     The update build information.
            /// </summary>
            UpdateBuildInformation = 0x40,

            /// <summary>
            ///     The queue builds.
            /// </summary>
            QueueBuilds = 0x80,

            /// <summary>
            ///     The manage build queue.
            /// </summary>
            ManageBuildQueue = 0x100,

            /// <summary>
            ///     The stop builds.
            /// </summary>
            StopBuilds = 0x200,

            /// <summary>
            ///     The view build definition.
            /// </summary>
            ViewBuildDefinition = 0x400,

            /// <summary>
            ///     The edit build definition.
            /// </summary>
            EditBuildDefinition = 0x800,

            /// <summary>
            ///     The delete build definition.
            /// </summary>
            DeleteBuildDefinition = 0x1000,

            /// <summary>
            ///     The override build check in validation.
            /// </summary>
            OverrideBuildCheckInValidation = 0x2000,

            /// <summary>
            ///     The all permissions.
            /// </summary>
            AllPermissions = 0x3FFF
        }

        /// <summary>
        ///     The warehouse permissions.
        /// </summary>
        [Flags]
        public enum WarehousePermissions
        {
            /// <summary>
            ///     The none.
            /// </summary>
            None = 0x0,

            /// <summary>
            ///     The administer.
            /// </summary>
            Administer = 0x1
        }

        #endregion
    }
}
