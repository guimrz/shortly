using System.Diagnostics.CodeAnalysis;

namespace Shortly.Core.Mapper.Abstractions
{
    public interface IMapper
    {
        [return: NotNullIfNotNull("value")]
        TDestination Map<TSource, TDestination>(TSource value);
    }
}
