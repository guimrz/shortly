using System.Diagnostics.CodeAnalysis;

namespace Shortly.Core.Extensions
{
    public static class CollectionExtensions
    {
        public static bool IsEmpty<T>(this IEnumerable<T> collection)
        {
            Guard.NotNull(collection);

            return !collection.Any();
        }

        public static bool IsNullOrEmpty<T>([MaybeNullWhen(true)] this IEnumerable<T> collection)
        {
            return collection is null || IsEmpty(collection);
        }
    }
}
