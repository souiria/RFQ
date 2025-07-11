using CDb.Data.Model.Components;
using CDb.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CDb.Data.Configuration.Components
{
    public class DbGrommetConfiguration : IEntityTypeConfiguration<DbGrommet>
    {
        public void Configure(EntityTypeBuilder<DbGrommet> builder)
        {
            builder.ToTable("Grommets");
            builder
                .Property(c => c.Location)
                .IsRequired()
                .HasMaxLength(32);
            builder
                .Property(c => c.AdditionalInformation)
                .HasMaxLength(256);
            builder
                .Property(c => c.Color)
                .IsRequired()
                .HasDefaultValue(ColorType.X);
        }
    }
}
