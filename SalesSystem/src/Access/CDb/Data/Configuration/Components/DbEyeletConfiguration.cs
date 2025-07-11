using CDb.Data.Model.Components;
using CDb.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CDb.Data.Configuration.Components
{
    public class DbEyeletConfiguration : IEntityTypeConfiguration<DbEyelet>
    {
        public void Configure(EntityTypeBuilder<DbEyelet> builder)
        {
            builder.ToTable("Eyelets");

            builder
                .Property(c => c.StudSize)
                .IsRequired()
                .HasDefaultValue(0);

            builder
                .Property(c => c.Thickness)
                .IsRequired()
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(8,1)");

            builder
                .Property(c => c.Angle)
                .IsRequired()
                .HasDefaultValue(0);

            builder
                .Property(c => c.IsWaterproof)
                .IsRequired()
                .HasDefaultValue(false);

            builder
                .Property(c => c.IsCr6Free)
                .IsRequired()
                .HasDefaultValue(false);

            builder
                .Property(c => c.PlatingType)
                .IsRequired()
                .HasDefaultValue(PlatingType.SN);
        }
    }
}
