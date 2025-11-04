namespace Rfq.Data.Configuration
{
    public class DbDsiPinMappingConfiguration : IEntityTypeConfiguration<DbDsiPinMapping>
    {
        public void Configure(EntityTypeBuilder<DbDsiPinMapping> builder)
        {
            builder.ToTable("DsiPinMapping");
            builder.HasKey(x => x.RowId);
        }
    }
}
