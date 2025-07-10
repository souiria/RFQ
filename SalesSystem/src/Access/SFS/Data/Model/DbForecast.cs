
namespace SFS.Data.Model
{
   public class DbForecast : IAggregateRoot
    {
        public int Period 
        { get; set; }
        public double ForecastCopperLevel 
        { get; set; }
        public double ForecastCopperWeight 
        { get; set; }
        public double PriceAdjustment 
        { get; set; }
    }
}
