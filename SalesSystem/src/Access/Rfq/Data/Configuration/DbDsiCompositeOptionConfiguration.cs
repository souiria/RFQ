namespace Rfq.Data.Configuration
{
    public class DbDsiCompositeOptionConfiguration : IEntityTypeConfiguration<DbDsiCompositeOption>
    {
        public void Configure(EntityTypeBuilder<DbDsiCompositeOption> builder)
        {
            builder.ToTable("DsiCompositeOption");
            builder.HasKey(x => x.RowId);
        }
    }
}
