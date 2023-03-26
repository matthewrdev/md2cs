namespace md2cs
{
    /// <summary>
    /// Defines a Material Design icon font.
    /// </summary>
    public class FontDefinition
    {
        /// <summary>
        /// The name of the icon font.
        /// </summary>
        public string FontName { get; set; }
        
        /// <summary>
        /// The endpoint from which the codepoints file can be obtained.
        /// </summary>
        public string CodePointsEndPoint { get; set; }
        
        /// <summary>
        /// A composite format string for the icon URL containing a parameter for the icon name. 
        /// </summary>
        public string IconUrlFormat { get; set; }
        
        /// <summary>
        /// The URL to the page for this font.
        /// </summary>
        public string SourceUrl { get; set; }
        
        /// <summary>
        /// Returns the class name for this font.
        /// </summary>
        public string ClassName => FontName?.Replace(" ", string.Empty);
    }
}