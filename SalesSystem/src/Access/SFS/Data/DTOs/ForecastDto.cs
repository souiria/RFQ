
namespace SFS.Data.DTOs
{
   public class ForecastDto
    {
        public int Period
        { get; set; }
        public decimal ForecastCopperLevel
        { get; set; }
        public decimal ForecastCopperWeight
        { get; set; }
        public decimal PriceAdjustment
        { get; set; }
    }
}
