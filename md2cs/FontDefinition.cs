namespace md2cs
{
    public class FontDefinition
    {
        public FontDefinition(string fontName, string endPoint)
        {
            FontName = fontName;
            EndPoint = endPoint;
        }
        
        public string FontName { get; }
        public string EndPoint { get; }
    }
}