using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using md2cs.Helpers;

namespace md2cs
{
    public static class MainClass
    {
        private static readonly List<FontDefinition> FontDefinitions = new List<FontDefinition>
        {
            new FontDefinition("MaterialDesignIcons", "https://raw.githubusercontent.com/google/material-design-icons/master/font/MaterialIcons-Regular.codepoints"),
            // Define extra font versions here
        };

        public static async Task Main(string[] args)
        {
            var exportPath = AssemblyHelper.EntryAssemblyDirectory;
            if (args != null && args.Any())
            {
                exportPath = args.First();
            }

            var outputPath = Path.Combine(exportPath, "md2cs-output");

            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath, true);
            }

            Directory.CreateDirectory(outputPath);

            foreach (var definition in FontDefinitions)
            {
                var downloadResult = await MaterialDesignDownloader.DownloadIconCodes(definition.EndPoint);
                var code = CodeWriter.Write(definition.FontName, downloadResult.Icons, downloadResult.IconUpdateDate);
            
                Console.WriteLine($"Writing output file for '{definition.FontName}'...");
                File.WriteAllText(Path.Combine(outputPath, $"{definition.FontName}.cs"), code);
            }

            Console.WriteLine("Opening output directory...");
            OpenFileHelper.OpenAndSelect(outputPath);
        }
    }
}
