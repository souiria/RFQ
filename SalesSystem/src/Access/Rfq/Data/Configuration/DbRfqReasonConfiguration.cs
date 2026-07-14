namespace Rfq.Data.Configuration
{
    public class DbRfqReasonConfiguration : IEntityTypeConfiguration<DbRfqReason>
    {
        public void Configure(EntityTypeBuilder<DbRfqReason> builder)
        {
            builder.ToTable("RfqReason");
            builder.HasKey(x => x.RowId);
        }
    }
}
