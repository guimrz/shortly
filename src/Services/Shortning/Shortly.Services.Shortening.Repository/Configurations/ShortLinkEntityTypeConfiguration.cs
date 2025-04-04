using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shortly.Services.Shortening.Domain;

namespace Shortly.Services.Shortening.Repository.Configurations
{
    public class ShortLinkEntityTypeConfiguration : IEntityTypeConfiguration<ShortLink>
    {
        public void Configure(EntityTypeBuilder<ShortLink> builder)
        {
            builder.ToTable("Shortlinks")
                .HasKey(p => p.Id);

            builder.Property(p => p.ShortCode)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(p => p.TenantId)
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
