using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace md2cs
{
    public static class MaterialDesignDownloader
    {
        public static async Task<IReadOnlyList<MaterialDesignIcon>> DownloadIconCodes(string endpoint)
        {
            using (var client = new HttpClient())
            {
                var assemblyName = typeof(MaterialDesignDownloader).Assembly.GetName();
                var productValue = new ProductInfoHeaderValue(assemblyName.Name.ToUpper(), assemblyName.Version.ToString(3));
                var commentValue = new ProductInfoHeaderValue("(+https://github.com/matthewrdev/md2cs)");
                client.DefaultRequestHeaders.UserAgent.Add(productValue);
                client.DefaultRequestHeaders.UserAgent.Add(commentValue);
                
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
