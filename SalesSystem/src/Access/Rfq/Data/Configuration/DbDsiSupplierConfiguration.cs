namespace Rfq.Data.Configuration
{
    public class DbDsiSupplierConfiguration : IEntityTypeConfiguration<DbDsiSupplier>
    {
        public void Configure(EntityTypeBuilder<DbDsiSupplier> builder)
        {
            builder.ToTable("DsiSupplier");
            builder.HasKey(x => x.RowId);
        }
    }
}
