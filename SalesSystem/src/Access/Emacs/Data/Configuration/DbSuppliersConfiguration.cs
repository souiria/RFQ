
namespace Emacs.Data.Configuration
{
    public class DbSuppliersConfiguration : IEntityTypeConfiguration<DbSuppliers>
    {
        public void Configure(EntityTypeBuilder<DbSuppliers> builder)
        {
            builder.ToTable("Suppliers");
            builder.HasNoKey();
        }
    }
}
