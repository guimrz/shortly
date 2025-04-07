namespace Shortly.Core.Mapper.Abstractions
{
    public interface ITypeMapper<TSource, TDestination>
    {
        TDestination Map(TSource source);
    }
}
