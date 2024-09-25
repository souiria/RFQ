namespace Edi.FileWatcher.Access.Data.Configurations;

internal class DbExternalSalesPriceInformationViewConfiguration : IEntityTypeConfiguration<DbExternalSalesPriceInformationView>
{
    public void Configure(EntityTypeBuilder<DbExternalSalesPriceInformationView> builder)
    {
        builder.ToView("vw_External_SalesPrices_OrderInformation");
        builder.HasNoKey();
        builder.Property(x => x.CustomerName).HasColumnName("Customer_Name");
        builder.Property(x => x.FinanceCode).HasColumnName("Finance_System_Code");
        builder.Property(x => x.ProductNumber).HasColumnName("Product_Number");
        builder.Property(x => x.CurrencyCode).HasColumnName("Currency");
        builder.Property(x => x.CurrencyCode).IsRequired(false);
        builder.Property(x => x.OrderPrice).HasColumnName("Order_Price");
        builder.Property(x => x.OrderPrice).HasColumnType("decimal(28, 6)");
        builder.Property(x => x.StartDate).HasColumnName("salesDB_effectivity_start_date");
        builder.Property(x => x.EndDate).HasColumnName("salesDB_effectivity_end_date");
        builder.Property(x => x.OrderNumber).IsRequired(false);
    }
}
