namespace Rfq.Data.Configuration
{
    public class DbDsiTransformedModuleChildDetailConfiguration : IEntityTypeConfiguration<DbDsiTransformedModuleChildDetail>
    {
        public void Configure(EntityTypeBuilder<DbDsiTransformedModuleChildDetail> builder)
        {
            builder.ToTable("DsiTransformedModuleChildDetail");
            builder.HasKey(x => x.RowId);
        }
    }
}
