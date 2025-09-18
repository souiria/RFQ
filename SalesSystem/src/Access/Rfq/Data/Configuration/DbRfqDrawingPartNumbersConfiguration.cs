namespace Rfq.Data.Configuration
{
    public class DbRfqDrawingPartNumbersConfiguration : IEntityTypeConfiguration<DbRfqDrawingPartNumber>
    {
        public void Configure(EntityTypeBuilder<DbRfqDrawingPartNumber> builder)
        {
            builder.ToTable("RfqDrawingPartNumber");
            builder.HasKey(x => x.RowId);
            builder.HasOne(x => x.RfqProject).WithMany(x => x.RfqDrawingPartNumbers).HasForeignKey(e => e.RfqId);
        }
    }
}
