using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKernel;
namespace SFS.Data.Model
{
    public class DbMonthlyVolumeData : IAggregateRoot
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
