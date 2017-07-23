using System;
using System.Text.RegularExpressions;

namespace Extension.Net
{
    public static partial class Extension
    {
        public static bool IsPattern(this string text, string pattern, RegexOptions options = RegexOptions.IgnoreCase)
        {
            if (text.IsNull())
                return false;

            Regex regex = new Regex(pattern, options);
            return regex.IsMatch(text);
        }
    }
}