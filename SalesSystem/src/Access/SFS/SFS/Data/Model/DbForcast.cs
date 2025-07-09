using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKernel;
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
