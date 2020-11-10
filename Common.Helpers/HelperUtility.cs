using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Common.Helpers
{
    public static class HelperUtility
    {
        static Regex regStripNonAlpha = new Regex(@"[^\w\s\-]+", RegexOptions.Compiled);
        static Regex regSpaceToDash = new Regex(@"[\s]+", RegexOptions.Compiled);

        public static string MakeUrlCompatible(string text)
        {
            return regSpaceToDash.Replace(
              regStripNonAlpha.Replace(text, string.Empty).Trim(), "-");
        }
    }
}
