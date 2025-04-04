using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Shortly.Core
{
    public static partial class Guard
    {
        public static object NotNull([NotNull] object? value, [CallerArgumentExpression(nameof(value))] string name = "")
        {
            return NotNull<object>(value, name);
        }

        public static T NotNull<T>([NotNull] T? value, [CallerArgumentExpression(nameof(value))] string name = "")
        {
            if (value is null)
            {
                throw new ArgumentNullException(name);
            }

            return value;
        }

        public static T NotDefault<T>(T value, [CallerArgumentExpression(nameof(value))] string name = "")
            where T : struct
        {
            if (value.Equals(default(T)))
            {
                throw new ArgumentException("The value cannot be the default value.", name);
            }

            return value;
        }
    }
}
