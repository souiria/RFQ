using System.ComponentModel.DataAnnotations.Schema;
using CDb.Data.Model.Masters;
using CDb.Enums;

namespace CDb.Data.Model.Components
{
    public class DbEyelet : DbComponent
    {
        public int StudSize 
        { get; set; }
        public decimal Thickness 
        { get; set; }
        public int Angle 
        { get; set; }
        public bool IsWaterproof 
        { get; set; }
        public bool IsCr6Free 
        { get; set; }
        public string Family 
        { get; set; }
        public string AdditionalInfo 
        { get; set; }
        public PlatingType PlatingType 
        { get; set; }

        public DbEyelet()
        {
            StudSize = 0;
            Thickness = 0.0m;
            Angle = 0;
            IsWaterproof = false;
            IsCr6Free = false;
            Family = string.Empty;
            AdditionalInfo = string.Empty;
            PlatingType = PlatingType.Undefined; // Default value
        }
    }
}
