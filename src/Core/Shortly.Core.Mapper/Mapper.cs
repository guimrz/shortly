using Shortly.Core.Mapper.Abstractions;

namespace Shortly.Core.Mapper
{
    public class Mapper : IMapper
    {
        protected readonly IServiceProvider serviceProvider;

        public Mapper(IServiceProvider serviceProvider)
        {
            this.serviceProvider = Guard.NotNull(serviceProvider);
        }

        public TDestination Map<TSource, TDestination>(TSource value)
        {
            if (value is null)
            {
                return default!;
            }
            else
            {
                value.GetType();

                var mapper = serviceProvider.GetService(typeof(ITypeMapper<TSource, TDestination>)) as ITypeMapper<TSource, TDestination>;

                if (mapper is null)
                {
                    throw new InvalidOperationException($"Could not map the type '{typeof(TSource).FullName}' to type '{typeof(TDestination).FullName}' because there's no mapper type defined in the services container for the specified types.");
                }

                return mapper.Map(value);
            }
        }
    }
}
