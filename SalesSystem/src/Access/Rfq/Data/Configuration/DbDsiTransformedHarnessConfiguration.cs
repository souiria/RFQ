namespace Rfq.Data.Configuration
{
    public class DbDsiTransformedHarnessConfiguration : IEntityTypeConfiguration<DbDsiTransformedHarness>
    {
        public void Configure(EntityTypeBuilder<DbDsiTransformedHarness> builder)
        {
            builder.ToTable("DsiTransformedHarness");
            builder.HasKey(x => x.RowId);
        }
    }
}
