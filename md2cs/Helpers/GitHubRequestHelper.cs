using System;
using System.Linq;

namespace md2cs.Helpers
{
    public static class GitHubRequestHelper
    {
        private const string CommitRequestTemplate =
            "https://api.github.com/repos$repo$commits?path=$filepath$&page=1&per_page=1";
        
        public static Uri GetCommitInfoRequestUri(string fileUrl, string branchName = "master")
        {
            var isGitHubUrl = fileUrl?.IndexOf("github", StringComparison.OrdinalIgnoreCase) >= 0;
            if (!isGitHubUrl)
                return null;

            var uriSegments = new Uri(fileUrl.TrimEnd('/')).Segments.ToList();
            var spitIndex = uriSegments.IndexOf($"{branchName.ToLower()}/");

            if (spitIndex < 0)
                throw new InvalidOperationException(
                    $"'{nameof(fileUrl)}' does not contain the specified '{nameof(branchName)}'");
            
            var repo = string.Concat(uriSegments.Take(spitIndex));
            var filePath = string.Concat(uriSegments.Skip(spitIndex + 1));
            var requestUri = new Uri(CommitRequestTemplate.Replace("$repo$", repo).Replace("$filepath$", filePath));
            return requestUri;
        }
    }
}