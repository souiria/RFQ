namespace Rfq.Data.Configuration
{
    public class DbDsiTransformedCompositeDetailConfiguration : IEntityTypeConfiguration<DbDsiTransformedCompositeDetail>
    {
        public void Configure(EntityTypeBuilder<DbDsiTransformedCompositeDetail> builder)
        {
            builder.ToTable("DsiTransformedCompositeDetail");
            builder.HasKey(x => x.RowId);
        }
    }
}
