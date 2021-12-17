using System;
using System.Collections.Generic;

namespace md2cs
{
    public class IconDownloadResult
    {
        public DateTimeOffset IconUpdateDate { get; set; }
        public List<MaterialDesignIcon> Icons { get; set; }
    }
}