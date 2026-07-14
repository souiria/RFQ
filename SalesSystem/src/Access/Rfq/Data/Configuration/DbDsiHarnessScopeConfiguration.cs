namespace Rfq.Data.Configuration
{
    public class DbDsiHarnessScopeConfiguration : IEntityTypeConfiguration<DbDsiHarnessScope>
    {
        public void Configure(EntityTypeBuilder<DbDsiHarnessScope> builder)
        {
            builder.ToTable("DsiHarnessScope");
            builder.HasKey(x => x.RowId);
        }
    }
}
