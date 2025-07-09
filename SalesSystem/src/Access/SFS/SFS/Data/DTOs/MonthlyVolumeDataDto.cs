using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFS.Data.DTOs
{
   public class MonthlyVolumeDataDto
    {
        public string? Profile
        { get; set; }
        public string? CarModel
        { get; set; }
        public int Year
        { get; set; }
        public int Month
        { get; set; }
        public int Volume
        { get; set; }
    }
}
