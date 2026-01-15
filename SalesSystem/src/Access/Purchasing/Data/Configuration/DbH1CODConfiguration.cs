namespace Purchasing.Data.Configuration
{
    public class DbH1CODConfiguration : IEntityTypeConfiguration<DbH1CPD>
    {
        public void Configure(EntityTypeBuilder<DbH1CPD> builder)
        {
            builder.ToTable("vw_H1_CPD");
            builder.Property(x => x.Price).HasPrecision(13, 5);
            builder.HasNoKey();
        }
    }
}
