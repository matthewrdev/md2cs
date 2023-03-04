namespace md2cs
{
    public class FontDefinition
    {
        public string FontName { get; set; }
        public string CodePointsEndPoint { get; set; }
        public string FontUrlFormat { get; set; }
        public string SourceUrl { get; set; }
        public string ClassName => FontName?.Replace(" ", string.Empty);
    }
}