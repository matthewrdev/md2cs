using System.Diagnostics;
using md2cs.Helpers;

namespace md2cs
{
    [DebuggerDisplay("{Name} - {DotNetName}")]
    public class MaterialDesignIcon
    {
        public MaterialDesignIcon(string name, string codepoint, string url)
        {
            Name = name;
            DotNetName = DotNetNameHelper.ToDotNetName(Name);
            Unicode = codepoint;
            Url = url;
        }

        public string Name { get; }
        public string Unicode { get; }
        public string Url { get; }
        public string DotNetName { get; }
    }
}
