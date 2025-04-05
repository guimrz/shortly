using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shortly.Services.Shortlinks.Domain;

namespace Shortly.Services.Shortlinks.Repository.Configurations
{
    public class ShortLinkEntityTypeConfiguration : IEntityTypeConfiguration<Shortlink>
    {
        public void Configure(EntityTypeBuilder<Shortlink> builder)
        {
            builder.ToTable("Shortlinks")
                .HasKey(p => p.Id)
                .IsClustered(false);

            builder.Property(p => p.ShortCode)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(p => p.OriginalUrl)
                .HasMaxLength(1024)
                .IsRequired();

            builder.Property(p => p.CreationDate)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.ExpirationDate)
                .IsRequired();

            builder.HasIndex(p => p.ShortCode)
                .IsClustered();
        }
    }
}
