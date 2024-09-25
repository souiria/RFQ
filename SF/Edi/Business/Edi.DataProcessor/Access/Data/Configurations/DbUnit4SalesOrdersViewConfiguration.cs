namespace Edi.DataProcessor.Access.Data.Configurations;

public class DbUnit4SalesOrdersViewConfiguration : IEntityTypeConfiguration<DbUnit4SalesOrdersView>
{
    public void Configure(EntityTypeBuilder<DbUnit4SalesOrdersView> builder)
    {
        RelationalEntityTypeBuilderExtensions.ToView((EntityTypeBuilder)builder, "vw_salesorders");
        builder.HasNoKey();
        builder.Property(x => x.FinanceCode).HasColumnName("apar_id");
        builder.Property(x => x.Client).HasColumnName("client");
        builder.Property(x => x.DespatchNumber).HasColumnName("deliv_attention");
        builder.Property(x => x.DespatchDate).HasColumnName("order_date");
        builder.Property(x => x.ProductNumber).HasColumnName("article");
        builder.Property(x => x.Status).HasColumnName("status");
    }
}

/*
 public string apar_id { get; set; }
    public string client {  get; set; }
    public string deliv_attention {  get; set; }
    public DateTime order_date { get; set; }
    public string article {  get; set; }
    public string status { get; set; }
 */
