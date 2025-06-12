
namespace Emacs.Data.Configuration
{
    public class DbNPACustomerConfiguration : IEntityTypeConfiguration<DbNPACustomer>
    {
        public void Configure(EntityTypeBuilder<DbNPACustomer> builder)
        {
            builder.ToTable("NPACustomer");
            builder.HasKey(x => x.Id);
        }
    }
}
