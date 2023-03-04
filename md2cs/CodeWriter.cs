using System;
using System.Collections.Generic;
using System.Linq;
using md2cs.Helpers;

namespace md2cs
{
    public static class CodeWriter
    {
        public static string Write(FontDefinition fontDefinition, IEnumerable<MaterialDesignIcon> icons, DateTimeOffset updateDate)
        {
            Console.WriteLine("Generating C# code...");

            var classTemplate = ResourcesHelper.ReadResourceContent("ClassTemplate.txt");
            var propertyTemplate = ResourcesHelper.ReadResourceContent("PropertyTemplate.txt");

            var properties = icons.Select(icon => propertyTemplate.Replace("$link$", icon.Url)
                    .Replace("$name$", icon.Name)
                    .Replace("$code$", icon.Unicode)
                    .Replace("$dotnet_name$", icon.DotNetName));

            var separator = Environment.NewLine + Environment.NewLine;
            var code = string.Join(separator, properties);

            return classTemplate
                .Replace("$class_name$", fontDefinition.ClassName)
                .Replace("$font_name$", fontDefinition.FontName)
                .Replace("$url$", fontDefinition.SourceUrl)
                .Replace("$update_date$", updateDate.ToString("yyyy-MM-dd"))
                .Replace("$properties$", code);
        }
    }
}
