using CDb.Data.Model.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CDb.Data.Configuration.Components
{
    public class DbCableConfiguration : IEntityTypeConfiguration<DbCable>
    {
        public void Configure(EntityTypeBuilder<DbCable> builder)
        {
            builder.ToTable("Cables");
            builder.Property(x => x.Color)
                .IsRequired();

            builder.Property(x => x.WireCountCode)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Length)
                .IsRequired()
                .HasColumnType("decimal(8,1)");

            builder.Property(x => x.IsShielded)
                .IsRequired();
        }
    }
}
