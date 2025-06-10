
namespace Emacs.Data.Configuration
{
    public class DbNPASupplierConfiguration : IEntityTypeConfiguration<DbNPASupplier>
    {
        public void Configure(EntityTypeBuilder<DbNPASupplier> builder)
        {
            builder.ToTable("NPASupplier");
            builder.HasKey(x => x.Id);
        }
    }
}
