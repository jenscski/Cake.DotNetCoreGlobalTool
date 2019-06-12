using Cake.Core;
using Cake.Core.Annotations;
using Cake.DotNetCoreGlobalTool.Install;
using Cake.DotNetCoreGlobalTool.List;
using Cake.DotNetCoreGlobalTool.Uninstall;
using Cake.DotNetCoreGlobalTool.Update;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cake.DotNetCoreGlobalTool
{
    /// <summary>
    ///
    /// </summary>
    [CakeAliasCategory("DotNetCore Global Tool")]
    public static class DotNetCoreGlobalToolAliases
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="context"></param>
        /// <param name="packageId"></param>
        /// <returns></returns>
        [CakeMethodAlias]
        public static bool DotNetCoreGlobalToolIsInstalled(this ICakeContext context, string packageId)
        {
            return context.DotNetCoreGlobalToolIsInstalled(packageId, null);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="context"></param>
        /// <param name="packageId"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        [CakeMethodAlias]
        [CakeNamespaceImport("Cake.DotNetCoreGlobalTool.List")]
        public static bool DotNetCoreGlobalToolIsInstalled(this ICakeContext context, string packageId, DotNetCoreGlobalToolListSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var items = context.DotNetCoreGlobalToolList(settings);

            return items.Any(x => x.Id.Equals(packageId, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [CakeMethodAlias]
        [CakeNamespaceImport("Cake.DotNetCoreGlobalTool.List")]
        public static IEnumerable<DotNetCoreGlobalToolItem> DotNetCoreGlobalToolList(this ICakeContext context)
        {
            return context.DotNetCoreGlobalToolList(null);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="context"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        [CakeMethodAlias]
        [CakeNamespaceImport("Cake.DotNetCoreGlobalTool.List")]
        public static IEnumerable<DotNetCoreGlobalToolItem> DotNetCoreGlobalToolList(this ICakeContext context, DotNetCoreGlobalToolListSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (settings == null)
            {
                settings = new DotNetCoreGlobalToolListSettings();
            }

            var runner = new DotNetCoreGlobalToolList(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            return runner.List(settings);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="context"></param>
        /// <param name="packageId"></param>
        [CakeMethodAlias]
        [CakeNamespaceImport("Cake.DotNetCoreGlobalTool.Install")]
        public static void DotNetCoreGlobalToolInstall(this ICakeContext context, string packageId)
        {
            context.DotNetCoreGlobalToolInstall(packageId, null);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="context"></param>
        /// <param name="packageId"></param>
        /// <param name="settings"></param>
        [CakeMethodAlias]
        [CakeNamespaceImport("Cake.DotNetCoreGlobalTool.Install")]
        public static void DotNetCoreGlobalToolInstall(this ICakeContext context, string packageId, DotNetCoreGlobalToolInstallSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (settings == null)
            {
                settings = new DotNetCoreGlobalToolInstallSettings();
            }

            var runner = new DotNetCoreGlobalToolInstall(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Install(packageId, settings);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="context"></param>
        /// <param name="packageId"></param>
        [CakeMethodAlias]
        [CakeNamespaceImport("Cake.DotNetCoreGlobalTool.Update")]
        public static void DotNetCoreGlobalToolUpdate(this ICakeContext context, string packageId)
        {
            context.DotNetCoreGlobalToolUpdate(packageId, null);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="context"></param>
        /// <param name="packageId"></param>
        /// <param name="settings"></param>
        [CakeMethodAlias]
        [CakeNamespaceImport("Cake.DotNetCoreGlobalTool.Update")]
        public static void DotNetCoreGlobalToolUpdate(this ICakeContext context, string packageId, DotNetCoreGlobalToolUpdateSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (settings == null)
            {
                settings = new DotNetCoreGlobalToolUpdateSettings();
            }

            var runner = new DotNetCoreGlobalToolUpdate(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Update(packageId, settings);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="context"></param>
        /// <param name="packageId"></param>
        [CakeMethodAlias]
        [CakeNamespaceImport("Cake.DotNetCoreGlobalTool.Uninstall")]
        public static void DotNetCoreGlobalToolUninstall(this ICakeContext context, string packageId)
        {
            context.DotNetCoreGlobalToolUninstall(packageId, null);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="context"></param>
        /// <param name="packageId"></param>
        /// <param name="settings"></param>
        [CakeMethodAlias]
        [CakeNamespaceImport("Cake.DotNetCoreGlobalTool.Uninstall")]
        public static void DotNetCoreGlobalToolUninstall(this ICakeContext context, string packageId, DotNetCoreGlobalToolUninstallSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (settings == null)
            {
                settings = new DotNetCoreGlobalToolUninstallSettings();
            }

            var runner = new DotNetCoreGlobalToolUninstall(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Uninstall(packageId, settings);
        }

    }
}
