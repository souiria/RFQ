using CDb.Data.Model.Masters;
using CDb.Enums;

namespace CDb.Data.Model.Components
{
    public class DbWire : DbComponent
    {
        public Guid WireTypeId 
        { get; set; }
        public DbWireType WireType 
        { get; set; } 
        public decimal WireSection 
        { get; set; }
        public int WireCount 
        { get; set; }
        public string Flexibility 
        { get; set; }
        public decimal InsulationThickness 
        { get; set; }
        public decimal BendingDiameter 
        { get; set; }
        public ColorType Color 
        { get; set; }
        public PlatingType PlatingType 
        { get; set; }

        public DbWire()
        {
            WireType = null!;
            WireTypeId = Guid.Empty;
            WireSection = 0.0m;
            WireCount = 0;
            Flexibility = string.Empty;
            InsulationThickness = 0.0m;
            BendingDiameter = 0.0m;
            Color = ColorType.X;
            PlatingType = PlatingType.None;
        }
    }
}
