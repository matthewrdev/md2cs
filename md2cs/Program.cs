using System.IO;
using System.Linq;
using System.Threading.Tasks;
using md2cs.Helpers;

namespace md2cs
{
    public static class MainClass
    {
        private const string Endpoint = "https://raw.githubusercontent.com/google/material-design-icons/master/font/MaterialIcons-Regular.codepoints";

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
            
            var icons = await MaterialDesignDownloader.DownloadIconCodes(Endpoint);

            var code = CodeWriter.Write(icons);

            File.WriteAllText(Path.Combine(exportPath, "MaterialDesignIcons.cs"), code);

            OpenFileHelper.OpenAndSelect(exportPath);
        }
    }
}
