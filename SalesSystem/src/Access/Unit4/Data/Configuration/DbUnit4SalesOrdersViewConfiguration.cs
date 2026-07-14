namespace Unit4.Data.Configuration
{
    public class DbUnit4SalesOrdersViewConfiguration : IEntityTypeConfiguration<DbUnit4SalesOrdersView>
    {
        public void Configure(EntityTypeBuilder<DbUnit4SalesOrdersView> builder)
        {
            builder.ToView("vw_salesorders");
            builder.HasNoKey();
            builder.Property(x => x.FinanceCode).HasColumnName("apar_id");
            builder.Property(x => x.Client).HasColumnName("client");
            builder.Property(x => x.DispatchNumber).HasColumnName("deliv_attention");
            builder.Property(x => x.DispatchDate).HasColumnName("order_date");
            builder.Property(x => x.ProductNumber).HasColumnName("article");
            builder.Property(x => x.Status).HasColumnName("status");
            builder.Property(x => x.OrderId).HasColumnName("order_id");
        }
    }
}
