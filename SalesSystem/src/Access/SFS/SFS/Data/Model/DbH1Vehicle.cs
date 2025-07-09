using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKernel;
namespace SFS.Data.Model
{
    public class DbH1Vehicle : IAggregateRoot
    {
        public Guid? Id 
        { get; set; }
        public string? VehicleName
        { get; set; }
        public string? ProjectReference 
        { get; set; }
        public string? VehicleDisplay
        { get; set; }
        public bool IsActive
        { get; set; }
    }
}
