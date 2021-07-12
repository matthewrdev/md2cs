using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace md2cs
{
    public static class MaterialDesignDownloader
    {
        public static async Task<IReadOnlyList<MaterialDesignIcon>> DownloadIconCodes(string endpoint)
        {
            using (var client = new HttpClient())
            {
                Console.WriteLine("Downloading: " + endpoint);

                var content = await client.GetStringAsync(endpoint);

                var icons = content.Split('\n')
                                                          .Where(c => !string.IsNullOrEmpty(c))
                                                          .Select(c => c.Split(' '))
                                                          .ToDictionary(c => c[0], c => c[1]);
                
                var result = icons.Select(icon => new MaterialDesignIcon(icon.Key, icon.Value)).ToList();

                Console.WriteLine("Discovered " + result.Count + " icons from " + endpoint);

                return result;
            }
        }
    }
}
