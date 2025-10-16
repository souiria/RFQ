namespace Rfq.Data.Configuration
{
    public class DbDsiCompositeDetailConfiguration : IEntityTypeConfiguration<DbDsiCompositeDetail>
    {
        public void Configure(EntityTypeBuilder<DbDsiCompositeDetail> builder)
        {
            builder.ToTable("DsiCompositeDetail");
            builder.HasKey(x => x.RowId);
        }
    }
}
