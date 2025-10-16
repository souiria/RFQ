namespace Rfq.Data.Configuration
{
    public class DbDsiHarnessConfiguration : IEntityTypeConfiguration<DbDsiHarness>
    {
        public void Configure(EntityTypeBuilder<DbDsiHarness> builder)
        {
            builder.ToTable("DsiHarness");
            builder.HasKey(x => x.RowId);
        }
    }
}
