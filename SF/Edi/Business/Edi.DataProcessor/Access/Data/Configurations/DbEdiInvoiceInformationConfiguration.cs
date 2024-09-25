namespace Edi.DataProcessor.Access.Data.Configurations;

internal class DbEdiInvoiceInformationConfiguration : IEntityTypeConfiguration<DbEdiInvoiceInformation>
{
    public void Configure(EntityTypeBuilder<DbEdiInvoiceInformation> builder)
    {
        RelationalEntityTypeBuilderExtensions.ToTable((EntityTypeBuilder)builder, "EdiInvoiceInformation");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Quantity).HasColumnType("decimal(28, 6)");
        builder.Property(x => x.ExchangeRate).HasColumnType("decimal(28, 4)");
        builder.Property(x => x.TotalGrossWeight).HasColumnType("decimal(28, 6)");
        builder.Property(x => x.TotalNetWeight).HasColumnType("decimal(28, 6)");
        builder.Property(x => x.OrderPrice).HasColumnType("decimal(28, 4)");
        builder.Property(x => x.TotalInvoicePrice).HasColumnType("decimal(28, 4)");
    }
}
