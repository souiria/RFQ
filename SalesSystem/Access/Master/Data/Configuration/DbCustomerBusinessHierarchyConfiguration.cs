namespace Master.Data.Configuration
{
    public class DbCustomerBusinessHierarchyConfiguration : IEntityTypeConfiguration<DbCustomerBusinessHierarchy>
    {
        public void Configure(EntityTypeBuilder<DbCustomerBusinessHierarchy> builder)
        {
            builder.ToTable("CustomerBusinessHierarchy");
            builder.HasKey(x => x.Id);
        }
    }
}
