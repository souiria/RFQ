namespace NPR.Data.Configuration
{
    public class DbH1NPRViewConfiguration : IEntityTypeConfiguration<DbH1NPRView>
    {
        public void Configure(EntityTypeBuilder<DbH1NPRView> builder)
        { 
            builder.ToTable("vw_H1_NPR");
            builder.Property(x => x.Qty_Per_Vehicle).HasPrecision(8,3);
            builder.Property(x => x.Price).HasPrecision(9,5);
            builder.Property(x => x.Copper_Weight).HasPrecision(10,5);
            builder.HasNoKey();
        }
    }
}
