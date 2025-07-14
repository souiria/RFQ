namespace CDb.Data.Model.Components
{
    public class DbRelay : DbComponent
    {
        public decimal Amperage
        { get; set; }
        public string Description
        { get; set; }
        public string Specification
        { get; set; }
        public ColorType Color
        { get; set; }

        public DbRelay()
        {
            Amperage = 0.0m;
            Description = string.Empty;
            Specification = string.Empty;
            Color = ColorType.X; // Default value
        }
    }
}
