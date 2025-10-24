namespace Rfq.Data.Configuration
{
    public class DbDsiWireMulticoreMarkerConfiguration : IEntityTypeConfiguration<DbDsiWireMulticoreMarker>
    {
        public void Configure(EntityTypeBuilder<DbDsiWireMulticoreMarker> builder)
        {
            builder.ToTable("DsiWireMulticoreMarker");
            builder.HasKey(x => x.RowId);
        }
    }
}
