namespace Rfq.Data.Configuration
{
    public class DbDsiCavityMappingConfiguration : IEntityTypeConfiguration<DbDsiCavityMapping>
    {
        public void Configure(EntityTypeBuilder<DbDsiCavityMapping> builder)
        {
            builder.ToTable("DsiCavityMapping");
            builder.HasKey(x => x.RowId);
        }
    }
}
