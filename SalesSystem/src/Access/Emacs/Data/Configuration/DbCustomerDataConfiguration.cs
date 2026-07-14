
namespace Emacs.Data.Configuration
{
    public class DbCustomerDataConfiguration : IEntityTypeConfiguration<DbCustomerData>
    {
        public void Configure(EntityTypeBuilder<DbCustomerData> builder)
        {
            builder.ToTable("CustomerData");
            builder.HasNoKey();
        }
    }
}
