using CDb.Data.Model.Components;
using CDb.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CDb.Data.Configuration.Components
{
    public class DbDiodeConfiguration : IEntityTypeConfiguration<DbDiode>
    {
        public void Configure(EntityTypeBuilder<DbDiode> builder)
        {
            builder.ToTable("Diodes");

            builder.Property(c => c.Amperage)
                .IsRequired()
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(5,1)");

            builder
                .Property(c => c.Color)
                .IsRequired()
                .HasDefaultValue(ColorType.X);
        }
    }
}
