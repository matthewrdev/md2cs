using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using md2cs.Helpers;

namespace md2cs
{
    public static class MaterialDesignDownloader
    {
        public static async Task<IconDownloadResult> DownloadIconCodes(FontDefinition fontDefinition)
        {
            using (var client = new HttpClient())
            {
                var assemblyName = typeof(MaterialDesignDownloader).Assembly.GetName();
                var productValue = new ProductInfoHeaderValue(assemblyName.Name.ToUpper(), assemblyName.Version.ToString(3));
                var commentValue = new ProductInfoHeaderValue("(+https://github.com/matthewrdev/md2cs)");
                client.DefaultRequestHeaders.UserAgent.Add(productValue);
                client.DefaultRequestHeaders.UserAgent.Add(commentValue);

                var result = new IconDownloadResult { IconUpdateDate = DateTimeOffset.Now };
                
                Console.WriteLine("Downloading: " + fontDefinition.CodePointsEndPoint);
                
                // Get real modification date to make it easier to match up with font files
                var requestUri = GitHubRequestHelper.GetCommitInfoRequestUri(fontDefinition.CodePointsEndPoint);
                if (requestUri != null)
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), requestUri))
                    {
                        var response = await client.SendAsync(request);
                        if (response.Content.Headers.LastModified.HasValue)
                            result.IconUpdateDate = response.Content.Headers.LastModified.Value;
                    }
                }

                var content = await client.GetStringAsync(fontDefinition.CodePointsEndPoint);

                var icons = content.Split('\n')
                    // ReSharper disable once CommentTypo
                    // Excluding "flourescent" (sic) as workaround for issue in MD font (https://github.com/google/material-design-icons/issues/1404)
                    // ReSharper disable once StringLiteralTypo
                    .Where(c => !string.IsNullOrEmpty(c) && !c.Contains("flourescent"))
                    .Select(c => c.Split(' '))
                    .ToDictionary(c => c[0], c => c[1]);
                
                result.Icons = icons.Select(icon => new MaterialDesignIcon(icon.Key, icon.Value, fontDefinition.FontUrlFormat.Replace("{name}", icon.Key))).ToList();

                Console.WriteLine("Discovered " + result.Icons.Count + " icons from " + fontDefinition.CodePointsEndPoint);

                return result;
            }
        }
    }
}
