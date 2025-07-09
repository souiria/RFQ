
namespace SFS.Data.Model
{
   public class DbForcast : IAggregateRoot
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
