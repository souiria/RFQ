namespace Master.Data.Configuration
{
    public class DbSupplierConfiguration : IEntityTypeConfiguration<DbSupplier>
    {
        public void Configure(EntityTypeBuilder<DbSupplier> builder)
        {
            builder.ToTable("Supplier");
            builder.HasKey(x => x.Id);
        }
    }
}
