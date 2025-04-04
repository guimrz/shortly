using Shortly.Core.Extensions;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Shortly.Core
{
    public static partial class Guard
    {
        public static string NotNullOrWhitespaces([NotNull] this string value, [CallerArgumentExpression(nameof(value))] string name = "")
        {
            if (value.IsNullOrWhiteSpaces())
            {
                throw new ArgumentException("The value cannot be a null reference, an empty string or whitespaces only", name);
            }

            return value;
        }
    }
}
