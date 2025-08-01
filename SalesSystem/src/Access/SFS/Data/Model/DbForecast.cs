
namespace SFS.Data.Model
{
   public class DbForecast : IAggregateRoot
    {
        public int Period 
        { get; set; }
        public decimal? ForecastCopperLevel 
        { get; set; }
        public decimal? ForecastCopperWeight 
        { get; set; }
        public decimal? PriceAdjustment 
        { get; set; }
    }
}
