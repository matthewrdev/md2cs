using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace md2cs
{
    public class MaterialDesignDownloader
    {
        public async Task<IReadOnlyList<MaterialDesignIcon>> DownloadIconCodes(string endpoint)
        {
            using (var client = new HttpClient())
            {
                Console.WriteLine("Downloading: " + endpoint);

                var content = await client.GetStringAsync(endpoint);

                Dictionary<string, string> icons = content.Split('\n')
                                                          .Where(c => !string.IsNullOrEmpty(c))
                                                          .Select(c => c.Split(' '))
                                                          .ToDictionary(c => c[0], c => c[1]);
                
                var result = new List<MaterialDesignIcon>();

                foreach (var icon in icons)
                {
                    result.Add(new MaterialDesignIcon(icon.Key, icon.Value));
                }

                Console.WriteLine("Discovered " + result.Count + " icons from " + endpoint);

                return result;
            }
        }
    }
}
