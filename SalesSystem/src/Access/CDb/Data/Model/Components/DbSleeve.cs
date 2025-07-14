namespace CDb.Data.Model.Components
{
    public class DbSleeve : DbComponent
    {
        public string Description
        { get; set; }
        public decimal Diameter
        { get; set; }
        public decimal Length
        { get; set; }
        public Guid WaterproofTypeId
        { get; set; }
        public DbWaterproofType WaterproofType
        { get; set; }
        public ColorType Color
        { get; set; }

        public DbSleeve()
        {
            // Initialize properties with default values
            Description = string.Empty;
            Diameter = 0.0m; // Default value
            Length = 0.0m; // Default value
            WaterproofType = null!; // Will be set later
            WaterproofTypeId = Guid.Empty; // Default value
            Color = ColorType.X; // Default value
        }
    }
}
