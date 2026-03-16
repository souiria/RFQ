namespace Master.Data.Configuration
{
    public class DbSupplierGroupConfiguration : IEntityTypeConfiguration<DbSupplierGroup>
    {
        public void Configure(EntityTypeBuilder<DbSupplierGroup> builder)
        {
            builder.ToTable("SupplierGroup");
            builder.HasKey(x => x.Id);
        }
    }
}
