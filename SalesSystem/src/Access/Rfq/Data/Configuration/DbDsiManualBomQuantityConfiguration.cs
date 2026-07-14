namespace Rfq.Data.Configuration
{
    public class DbDsiManualBomQuantityConfiguration : IEntityTypeConfiguration<DbDsiManualBomQuantity>
    {
        public void Configure(EntityTypeBuilder<DbDsiManualBomQuantity> builder)
        {
            builder.ToTable("DsiManualBomQuantity");
            builder.HasKey(x => x.RowId);
        }
    }
}
