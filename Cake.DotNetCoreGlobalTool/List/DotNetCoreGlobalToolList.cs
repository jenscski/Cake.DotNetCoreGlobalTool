using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Cake.DotNetCoreGlobalTool.List
{
    /// <summary>
    ///
    /// </summary>
    public sealed class DotNetCoreGlobalToolList : DotNetCoreGlobalTool<DotNetCoreGlobalToolListSettings>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="fileSystem"></param>
        /// <param name="environment"></param>
        /// <param name="processRunner"></param>
        /// <param name="tools"></param>
        public DotNetCoreGlobalToolList(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public IEnumerable<DotNetCoreGlobalToolItem> List(DotNetCoreGlobalToolListSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var processSettings = new ProcessSettings
            {
                RedirectStandardOutput = true
            };

            IEnumerable<string> result = null;
            Run(settings, GetArguments(settings), processSettings, process => result = process.GetStandardOutput());

            var pattern = @"([^\s]+)\s+([^\s]+)\s+([^\s]+)";

            var items = result.Skip(2)
                .Select(x => Regex.Match(x, pattern))
                .Where(x => x.Success)
                .Select(x => new DotNetCoreGlobalToolItem
                {
                    Id = x.Groups[1].Value,
                    Version = x.Groups[2].Value,
                    Commands = x.Groups[3].Value,
                });

            return items.ToList();
        }

        private ProcessArgumentBuilder GetArguments(DotNetCoreGlobalToolListSettings settings)
        {
            var builder = new ProcessArgumentBuilder();

            builder.Append("tool");
            builder.Append("list");
            builder.Append("-g");

            return builder;
        }
    }
}
