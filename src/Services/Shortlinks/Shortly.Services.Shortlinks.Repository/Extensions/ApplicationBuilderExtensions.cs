using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shortly.Core;

namespace Shortly.Services.Shortlinks.Repository.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseShortlinksServiceRepository(this IApplicationBuilder applicationBuilder)
        {
            Guard.NotNull(applicationBuilder);

            using var scope = applicationBuilder.ApplicationServices.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ShortlinksServiceDbContext>();

            dbContext.Database.Migrate();

            return applicationBuilder;
        }
    }
}
