using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using System;

namespace Cake.DotNetCoreGlobalTool.Install
{
    /// <summary>
    ///
    /// </summary>
    public sealed class DotNetCoreGlobalToolInstall : DotNetCoreGlobalTool<DotNetCoreGlobalToolInstallSettings>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="fileSystem"></param>
        /// <param name="environment"></param>
        /// <param name="processRunner"></param>
        /// <param name="tools"></param>
        public DotNetCoreGlobalToolInstall(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="packageId"></param>
        /// <param name="settings"></param>
        public void Install(string packageId, DotNetCoreGlobalToolInstallSettings settings)
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

        private ProcessArgumentBuilder GetArguments(string packageId, DotNetCoreGlobalToolInstallSettings settings)
        {
            var builder = new ProcessArgumentBuilder();

            builder.Append("tool");
            builder.Append("install");
            builder.Append("-g");

            if (settings.Version != null)
                builder.AppendSwitchQuoted("--version", settings.Version);

            if (settings.ConfigFile != null)
                builder.AppendSwitchQuoted("--configfile", settings.ConfigFile);

            if (settings.Source != null)
                builder.AppendSwitchQuoted("--add-source", settings.Source);

            if (settings.Framework != null)
                builder.AppendSwitchQuoted("--framework", settings.Framework);

            if (settings.DisableParallel)
                builder.Append("--disable-parallel");

            if (settings.IgnoreFailedSources)
                builder.Append("--ignore-failed-sources");

            if (settings.NoCache)
                builder.Append("--no-cache");

            builder.AppendQuoted(packageId);

            return builder;
        }
    }
}
