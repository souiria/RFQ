namespace SFS.Data.Configuration
{
    public class DbCustomerConfiguration : IEntityTypeConfiguration<DbCustomer>
    {
        public void Configure(EntityTypeBuilder<DbCustomer> builder)
        {
            builder.ToTable("tblCustomer");
            builder.HasKey(x => x.Id);
        }
    }
}
