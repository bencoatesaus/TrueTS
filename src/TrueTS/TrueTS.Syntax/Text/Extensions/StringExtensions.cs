using System;
using System.Linq;

namespace TrueTS.Syntax.Text.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNumeric(this string text)
        {
            return text.ToCharArray().All(c => c.IsNumber());
        }
    }
}
