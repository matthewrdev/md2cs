using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using md2cs.Helpers;

namespace md2cs
{
    class MainClass
    {
        public const string Endpoint = "https://raw.githubusercontent.com/google/material-design-icons/master/iconfont/codepoints";

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

            var downloader = new MaterialDesignDownloader();
            var codeWriter = new CodeWriter();

            var icons = await downloader.DownloadIconCodes(Endpoint);

            var code = codeWriter.Write(icons);

            File.WriteAllText(Path.Combine(exportPath, "MaterialDesignIcons.cs"), code);

            OpenFileHelper.OpenAndSelect(exportPath);
        }
    }
}
