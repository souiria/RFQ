namespace Rfq.Data.Configuration
{
    public class DbDsiPinMappingCavityMappingAssociationConfiguration : IEntityTypeConfiguration<DbDsiPinMappingCavityMappingAssociation>
    {
        public void Configure(EntityTypeBuilder<DbDsiPinMappingCavityMappingAssociation> builder)
        {
            builder.ToTable("DsiPinMappingCavityMappingAssociation");
            builder.HasKey(x => x.RowId);
        }
    }
}
