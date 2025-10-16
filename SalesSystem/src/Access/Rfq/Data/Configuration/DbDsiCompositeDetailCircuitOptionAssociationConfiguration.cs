namespace Rfq.Data.Configuration
{
    public class DbDsiCompositeDetailCircuitOptionAssociationConfiguration : IEntityTypeConfiguration<DbDsiCompositeDetailCircuitOptionAssociation>
    {
        public void Configure(EntityTypeBuilder<DbDsiCompositeDetailCircuitOptionAssociation> builder)
        {
            builder.ToTable("DsiCompositeDetailCircuitOptionAssociation");
            builder.HasKey(x => x.RowId);
        }
    }
}
