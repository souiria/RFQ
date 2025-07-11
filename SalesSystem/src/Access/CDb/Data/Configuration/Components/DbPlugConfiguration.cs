using CDb.Data.Model.Components;
using CDb.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CDb.Data.Configuration.Components
{
    public class DbPlugConfiguration : IEntityTypeConfiguration<DbPlug>
    {
        public void Configure(EntityTypeBuilder<DbPlug> builder)
        {
            builder.ToTable("Plugs");

            builder.Property(c => c.Diameter)
                .IsRequired()
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(8,1)");

            builder.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(c => c.Color)
                .IsRequired()
                .HasDefaultValue(ColorType.X);
        }
    }
}
