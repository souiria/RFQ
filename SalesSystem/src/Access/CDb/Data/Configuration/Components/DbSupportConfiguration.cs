using CDb.Data.Model.Components;
using CDb.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CDb.Data.Configuration.Components
{
    public class DbSupportConfiguration : IEntityTypeConfiguration<DbSupport>
    {
        public void Configure(EntityTypeBuilder<DbSupport> builder)
        {
            builder.ToTable("Supports");

            builder
                .Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(32);

            builder
                .Property(c => c.AdditionalInformation)
                .IsRequired()
                .HasMaxLength(32);

            builder
                .Property(c => c.Color)
                .IsRequired()
                .HasDefaultValue(ColorType.X);
        }
    }
}
