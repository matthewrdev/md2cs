using System;
using System.Collections.Generic;
using System.Linq;

namespace md2cs.Helpers
{
    public static class DotNetNameHelper
    {
        private static readonly IReadOnlyDictionary<string, string> DotNetNameMap = new Dictionary<string, string>
        {
            { "3d_rotation", "Rotation3D" },
            { "360", "ThreeSixty"},
            { "3p", "ThirdPerson"},
            { "123", "OneTwoThree"}
        };

        private static readonly IReadOnlyDictionary<string, string> SuffixMap = new Dictionary<string, string>
        {
            { "mp", "MegaPixels" }, // Generally clearer to use the full words for this when using numbers as words
            { "k", "K"},
            { "ft", "Ft"},
            {"m", "m"},
        };
        
        private static readonly string[] UnitsMap = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        private static readonly string[] TensMap = { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        
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

            // Convert underscore-seperated names to camelCase/PascalCase
            var split = name.Split('_');
            var dotNetName = split.Aggregate("", (current, s) => current + s.FirstCharToUpper());

            // Extract any proceeding number (C# var names can't start with numeric literals) 
            var number = new string(dotNetName.TakeWhile(char.IsDigit).ToArray());
            if (!number.Any()) return dotNetName;
            
            // Convert number prefix to words
            var ending = string.Empty;
            if (dotNetName.Length > number.Length)
            {
                var nameAfterNumber = dotNetName.Substring(number.Length);
                var lowerSuffix = nameAfterNumber.ToLower();
                // Respect capitalisation of known suffixes, otherwise capitalise first char for Pascal case
                ending = SuffixMap.ContainsKey(lowerSuffix) ? SuffixMap[lowerSuffix] : nameAfterNumber.FirstCharToUpper();
            }
            var numberAsWords = NumberToWords(int.Parse(number));
            return numberAsWords + ending;
        }
        
        private static string NumberToWords(int number)
        {
            const char separator = '_';

            if (number == 0)
                return "Zero";

            if (number < 0)
                return "Minus" + separator + NumberToWords(Math.Abs(number));

            var words = string.Empty;

            if (number / 1000000 > 0)
            {
                words += NumberToWords(number / 1000000) + "Million" + separator;
                number %= 1000000;
            }

            if (number / 1000 > 0)
            {
                words += NumberToWords(number / 1000) + "Thousand" + separator;
                number %= 1000;
            }

            if (number / 100 > 0)
            {
                words += NumberToWords(number / 100) + "Hundred" + separator;
                number %= 100;
            }

            if (number > 0)
            {
                if (words != string.Empty)
                    words += "And" + separator;

                if (number < 20)
                    words += UnitsMap[number];
                else
                {
                    words += TensMap[number / 10];
                    if (number % 10 > 0)
                        words += UnitsMap[number % 10];
                }
            }

            return words.TrimEnd(separator);
        }
    }
}
