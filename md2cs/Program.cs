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
            new FontDefinition
            {
                FontName = "Material Icons",
                CodePointsEndPoint = "https://raw.githubusercontent.com/google/material-design-icons/master/font/MaterialIcons-Regular.codepoints",
                IconUrlFormat = "https://fonts.google.com/icons?selected=Material+Icons:{0}",
                SourceUrl = "https://fonts.google.com/icons?selected=Material+Icons"
            },
            new FontDefinition
            {
                FontName = "Material Symbols",
                CodePointsEndPoint = "https://raw.githubusercontent.com/google/material-design-icons/master/variablefont/MaterialSymbolsOutlined%5BFILL%2CGRAD%2Copsz%2Cwght%5D.codepoints",
                IconUrlFormat = "https://fonts.google.com/icons?selected=Material+Symbols+Outlined:{0}",
                SourceUrl = "https://fonts.google.com/icons?selected=Material+Symbols"
            }
            // Define extra font versions here
        };

        public static async Task Main(string[] args)
        {
            var exportPath = AssemblyHelper.EntryAssemblyDirectory;
            
            
            exportPath = Path.Combine(exportPath, "../../../");
            exportPath = Path.GetFullPath(exportPath);
            
            if (args != null && args.Any())
            {
                exportPath = args.First();
            }


            foreach (var definition in FontDefinitions)
            {
                var downloadResult = await MaterialDesignDownloader.DownloadIconCodes(definition);
                var code = CodeWriter.Write(definition, downloadResult.Icons, downloadResult.IconUpdateDate);
            
                Console.WriteLine($"Writing output file for '{definition.FontName}'...");
                File.WriteAllText(Path.Combine(exportPath, $"{definition.ClassName}.cs"), code);
            }

            Console.WriteLine("Opening output directory...");
            OpenFileHelper.OpenAndSelect(exportPath);
        }
    }
}
