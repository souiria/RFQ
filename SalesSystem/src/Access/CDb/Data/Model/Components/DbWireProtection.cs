using CDb.Data.Model.Masters;
using CDb.Enums;

namespace CDb.Data.Model.Components
{
    public class DbWireProtection : DbComponent
    {
        public Guid WireProtectionTypeId
        { get; set; }
        public DbWireProtectionType WireProtectionType
        { get; set; }
        public string Description 
        { get; set; }
        public decimal TapeWidth 
        { get; set; }
        public decimal TubeDiameter 
        { get; set; }
        public string Specification 
        { get; set; }
        public string AdditionalInformation 
        { get; set; }
        public ColorType Color 
        { get; set; }

        public DbWireProtection()
        {
            WireProtectionType = null!;
            WireProtectionTypeId = Guid.Empty;
            Description = string.Empty;
            TapeWidth = 0.0m;
            TubeDiameter = 0.0m;
            Specification = string.Empty;
            AdditionalInformation = string.Empty;
            Color = ColorType.X;
        }
    }
}
