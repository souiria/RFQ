namespace Rfq.Data.Configuration
{
    public class DbDsiModuleChildDetailConfiguration : IEntityTypeConfiguration<DbDsiModuleChildDetail>
    {
        public void Configure(EntityTypeBuilder<DbDsiModuleChildDetail> builder)
        {
            builder.ToTable("DsiModuleChildDetail");
            builder.HasKey(x => x.RowId);
        }
    }
}
