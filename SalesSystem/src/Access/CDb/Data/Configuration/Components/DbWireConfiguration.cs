using CDb.Data.Model.Components;
using CDb.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CDb.Data.Configuration.Components
{
    public class DbWireConfiguration : IEntityTypeConfiguration<DbWire>
    {
        public void Configure(EntityTypeBuilder<DbWire> builder)
        {
            builder.ToTable("Wires");

            builder
                .HasOne(c => c.WireType)
                .WithMany()
                .HasForeignKey(c => c.WireTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.WireSection)
                .IsRequired()
                .HasColumnType("decimal(5,1)")
                .HasDefaultValue(0.0m);

            builder.Property(c => c.WireSection)
                .IsRequired()
                .HasColumnType("decimal(5,1)")
                .HasDefaultValue(0.0m);

            builder.Property(c => c.WireCount)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(c => c.Flexibility)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(c => c.InsulationThickness)
                .IsRequired()
                .HasColumnType("decimal(5,1)")
                .HasDefaultValue(0.0m);

            builder.Property(c => c.BendingDiameter)
                .IsRequired()
                .HasColumnType("decimal(5,1)")
                .HasDefaultValue(0.0m);

            builder
                .Property(c => c.Color)
                .IsRequired()
                .HasDefaultValue(ColorType.X);

            builder
                .Property(c => c.PlatingType)
                .IsRequired()
                .HasDefaultValue(PlatingType.SN);
        }
    }
}
