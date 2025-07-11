using CDb.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CDb.Data.Configuration
{
    public class DbDrawingNumberConfiguration : IEntityTypeConfiguration<DbDrawingNumber>
    {
        public void Configure(EntityTypeBuilder<DbDrawingNumber> builder)
        {
            builder.ToTable("DrawingNumbers");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Number)
                .IsRequired()
                .HasMaxLength(512);

            builder.Property(x => x.DrawingNumberType)
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder
                .HasOne(x => x.Component)
                .WithMany()
                .HasForeignKey(x => x.ComponentId);
        }
    }
}