using System.Diagnostics.CodeAnalysis;

namespace Shortly.Core.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrWhiteSpaces([MaybeNullWhen(true)]this string value) 
        {
            return string.IsNullOrWhiteSpace(value);
        }
    }
}
