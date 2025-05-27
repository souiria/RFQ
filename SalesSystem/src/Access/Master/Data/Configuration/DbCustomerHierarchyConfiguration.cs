namespace Master.Data.Configuration
{
    public class DbCustomerHierarchyConfiguration : IEntityTypeConfiguration<DbCustomerHierarchy>
    {
        public void Configure(EntityTypeBuilder<DbCustomerHierarchy> builder)
        {
            builder.ToTable("CustomerHierarchy");
            builder.HasKey(x => x.Id);
        }
    }
}
