namespace Rfq.Data.Configuration
{
    public class DbDsiScopeConfiguration : IEntityTypeConfiguration<DbDsiScope>
    {
        public void Configure(EntityTypeBuilder<DbDsiScope> builder)
        {
            builder.ToTable("DsiScope");
            builder.HasKey(x => x.RowId);
        }
    }
}
