using Edi.Unit4DataValidator.Access.Data.Models;

namespace Edi.Unit4DataValidator.Access.Data.Configurations;
internal class DbEdiInvoiceUnit4Configuration : IEntityTypeConfiguration<DbEdiInvoiceUnit4>
{
    public void Configure(EntityTypeBuilder<DbEdiInvoiceUnit4> builder)
    {
        builder.ToTable("EdiInvoiceUnit4");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Quantity).HasColumnType("decimal(28, 6)");
        builder.Property(x => x.ExchangeRate).HasColumnType("decimal(28, 4)");
        builder.Property(x => x.TotalGrossWeight).HasColumnType("decimal(28, 6)");
        builder.Property(x => x.TotalNetWeight).HasColumnType("decimal(28, 6)");
        builder.Property(x => x.OrderPrice).HasColumnType("decimal(28, 4)");
        builder.Property(x => x.TotalInvoicePrice).HasColumnType("decimal(28, 4)");
    }
}
