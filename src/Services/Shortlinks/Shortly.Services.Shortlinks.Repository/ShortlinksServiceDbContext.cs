using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Shortly.Services.Shortlinks.Repository
{
    public class ShortlinksServiceDbContext : DbContext
    {
        public ShortlinksServiceDbContext(DbContextOptions<ShortlinksServiceDbContext> options) 
            : base(options)
        {
            //
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
