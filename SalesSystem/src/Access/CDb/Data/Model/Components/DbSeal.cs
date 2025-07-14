namespace CDb.Data.Model.Components
{
    public class DbSeal : DbComponent
    {
        public string Description
        { get; set; }
        public decimal Diameter
        { get; set; }
        public ColorType Color
        { get; set; }

        public DbSeal()
        {
            // Initialize properties with default values
            Description = string.Empty;
            Diameter = 0.0m; // Default value
            Color = ColorType.X; // Default value
        }
    }
}
