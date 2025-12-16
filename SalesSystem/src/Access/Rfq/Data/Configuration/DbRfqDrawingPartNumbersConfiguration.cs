using Microsoft.EntityFrameworkCore;

namespace Rfq.Data.Configuration
{
    public class DbRfqDrawingPartNumbersConfiguration : IEntityTypeConfiguration<DbRfqDrawingPartNumber>
    {
        public void Configure(EntityTypeBuilder<DbRfqDrawingPartNumber> builder)
        {
            builder.ToTable("RfqDrawingPartNumber");
            builder.HasKey(x => x.RowId);
            builder
                .Property(p => p.OriginalPartNumberPrice)
                .HasPrecision(18, 6);
            builder
                .Property(p => p.SwappedPartNumberPrice)
                .HasPrecision(18, 6);
            builder.HasOne(x => x.RfqProject).WithMany(x => x.RfqDrawingPartNumbers).HasForeignKey(e => e.RfqId);
        }
    }
}
