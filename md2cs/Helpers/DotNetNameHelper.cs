using System.Collections.Generic;

namespace md2cs.Helpers
{
    public static class DotNetNameHelper
    {
        public static readonly IReadOnlyDictionary<string, string> DotNetNameMap = new Dictionary<string, string>()
        {
            { "3d_rotation", "Rotation3D" }
        };

        public static string ToDotNetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return string.Empty;
            }

            if (DotNetNameMap.ContainsKey(name))
            {
                return DotNetNameMap[name];
            }

            var split = name.Split('_');

            var dotNetName = "";
            foreach (var s in split)
            {
                dotNetName += s.FirstCharToUpper();
            }

            return dotNetName;
        }
    }
}
