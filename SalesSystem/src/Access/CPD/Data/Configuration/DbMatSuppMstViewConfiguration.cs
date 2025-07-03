namespace CPD.Data.Configuration
{
    public class DbMatSuppMstViewConfiguration : IEntityTypeConfiguration<DbMattSuppMstView>
    {
        public void Configure(EntityTypeBuilder<DbMattSuppMstView> builder)
        {
            builder.ToTable("vw_MatSupp_Mst");
            builder.Property(x => x.Po_Price).HasPrecision(13, 5);
            builder.Property(x => x.Standard_Box_Length).HasPrecision(5, 3);
            builder.Property(x => x.Standard_Box_Width).HasPrecision(5, 3);
            builder.Property(x => x.Standard_Box_Heigh).HasPrecision(5, 3);
            builder.Property(x => x.Copper_Wt).HasPrecision(16, 6);
            builder.Property(x => x.Copper_Rate).HasPrecision(16, 6);
            builder.Property(x => x.PO_Price_Excopper).HasPrecision(13, 5);
            builder.Property(x => x.Initial_Vol_Qty).HasPrecision(12, 0);
            builder.Property(x => x.Full_Box_Weight).HasPrecision(6, 2);
            builder.Property(x => x.ExchangeRate).HasPrecision(10, 5);
            builder.HasNoKey();
        }
    }
}
