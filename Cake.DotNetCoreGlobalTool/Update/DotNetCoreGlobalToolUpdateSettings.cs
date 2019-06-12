using Cake.Core.Tooling;

namespace Cake.DotNetCoreGlobalTool.Update
{
    /// <summary>
    ///
    /// </summary>
    public sealed class DotNetCoreGlobalToolUpdateSettings : ToolSettings
    {
        /// <summary>
        /// The version of the tool package to install.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// The NuGet configuration file to use.
        /// </summary>
        public string ConfigFile { get; set; }

        /// <summary>
        /// Add an additional NuGet package source to use during installation.
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// The target framework to install the tool for.
        /// </summary>
        public string Framework { get; set; }

        /// <summary>
        /// Prevent restoring multiple projects in parallel.
        /// </summary>
        public bool DisableParallel { get; set; }

        /// <summary>
        /// Treat package source failures as warnings.
        /// </summary>
        public bool IgnoreFailedSources { get; set; }

        /// <summary>
        /// Do not cache packages and http requests.
        /// </summary>
        public bool NoCache { get; set; }
    }
}
