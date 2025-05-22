namespace Master.Data.Configuration
{
    public class DbCustomerSalesEntityConfiguration : IEntityTypeConfiguration<DbCustomerSalesEntity>
    {
        public void Configure(EntityTypeBuilder<DbCustomerSalesEntity> builder)
        {
            builder.ToTable("CustomerSalesEntityHierarchy");
            builder.HasKey(x => x.Id);
        }
    }
}
