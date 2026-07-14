
namespace CPD.Data.Configuration
{
    public class DbHarnessCostingCalculationDataViewConfiguration : IEntityTypeConfiguration<DbHarnessCostingCalculationDataView>
    {
        public void Configure(EntityTypeBuilder<DbHarnessCostingCalculationDataView> builder)
        {
            builder.ToTable("vw_Harness_Costing_Calculation_Data");
            builder.Property(x => x.Po_Price).HasPrecision(13, 5);
            builder.Property(x => x.ExchangeRate).HasPrecision(10, 5);
            builder.HasNoKey();
        }
    }
}
