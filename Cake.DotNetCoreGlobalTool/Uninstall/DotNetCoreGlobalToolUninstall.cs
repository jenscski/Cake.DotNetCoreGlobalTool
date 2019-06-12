using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using System;

namespace Cake.DotNetCoreGlobalTool.Uninstall
{
    /// <summary>
    ///
    /// </summary>
    public sealed class DotNetCoreGlobalToolUninstall : DotNetCoreGlobalTool<DotNetCoreGlobalToolUninstallSettings>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="fileSystem"></param>
        /// <param name="environment"></param>
        /// <param name="processRunner"></param>
        /// <param name="tools"></param>
        public DotNetCoreGlobalToolUninstall(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="packageId"></param>
        /// <param name="settings"></param>
        public void Uninstall(string packageId, DotNetCoreGlobalToolUninstallSettings settings)
        {
            if (packageId == null)
            {
                throw new ArgumentNullException(nameof(packageId));
            }

            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            Run(settings, GetArguments(packageId, settings));
        }

        private ProcessArgumentBuilder GetArguments(string packageId, DotNetCoreGlobalToolUninstallSettings settings)
        {
            var builder = new ProcessArgumentBuilder();

            builder.Append("tool");
            builder.Append("uninstall");
            builder.Append("-g");

            builder.AppendQuoted(packageId);

            return builder;
        }
    }
}
