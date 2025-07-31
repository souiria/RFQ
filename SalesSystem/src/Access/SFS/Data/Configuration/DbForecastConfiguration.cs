namespace SFS.Data.Configuration
{
    public class DbForecastConfiguration : IEntityTypeConfiguration<DbForecast>
    {
        public void Configure(EntityTypeBuilder<DbForecast> builder)
        {
            builder.HasNoKey();
            builder.ToView("ForecastView");  
        }
    }
}
