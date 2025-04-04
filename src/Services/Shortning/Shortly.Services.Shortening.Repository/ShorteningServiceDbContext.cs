using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Shortly.Services.Shortening.Repository
{
    public class ShorteningServiceDbContext : DbContext
    {
        public ShorteningServiceDbContext(DbContextOptions<ShorteningServiceDbContext> options) 
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
