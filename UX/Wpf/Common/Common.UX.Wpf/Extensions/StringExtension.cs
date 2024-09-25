using System;

namespace Common.UX.Wpf.Extensions
{
    public static class StringExtension
    {
        public static bool Contains(this string text, string value,
            StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase)
        {
            return text.IndexOf(value, stringComparison) >= 0;
        }
    }
}
