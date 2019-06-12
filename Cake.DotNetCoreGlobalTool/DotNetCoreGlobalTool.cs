using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using System.Collections.Generic;

namespace Cake.DotNetCoreGlobalTool
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TSettings"></typeparam>
    public abstract class DotNetCoreGlobalTool<TSettings> : Tool<TSettings>
        where TSettings : ToolSettings
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="fileSystem"></param>
        /// <param name="environment"></param>
        /// <param name="processRunner"></param>
        /// <param name="tools"></param>
        protected DotNetCoreGlobalTool(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        /// <summary>
        /// Gets the name of the tool.
        /// </summary>
        /// <returns>The name of the tool.</returns>
        protected override string GetToolName()
        {
            return ".NET Core CLI";
        }

        /// <summary>
        /// Gets the possible names of the tool executable.
        /// </summary>
        /// <returns>The tool executable name.</returns>
        protected override IEnumerable<string> GetToolExecutableNames()
        {
            return new[] { "dotnet", "dotnet.exe" };
        }
    }
}
