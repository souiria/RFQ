namespace Commercial.Data.Configuration
{
    public class DbPurchaseOrderConfiguration : IEntityTypeConfiguration<DbPurchaseOrder>
    {
        public void Configure(EntityTypeBuilder<DbPurchaseOrder> builder)
        {
            builder.ToTable("Interface_WH_Purchase_Order_Merged_Filtered_Data");
            builder.HasKey(x => x.Id);
        }
    }
}
