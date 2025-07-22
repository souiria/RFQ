namespace CDb.Data.Model.Components
{
    public class DbMiscellaneousComponent : DbComponent
    {
        public Guid MiscellaneousComponentTypeId
        { get; set; }
        public DbMiscellaneousComponentType MiscellaneousComponentType
        { get; set; }
        public string? Dimension
        { get; set; }
        public string? AdditionaInfo
        { get; set; }
        public ColorType Color
        { get; set; }

        public DbMiscellaneousComponent()
        {
            // Initialize properties with default values
            MiscellaneousComponentType = null!;
            MiscellaneousComponentTypeId = Guid.Empty;
            Dimension = null;
            AdditionaInfo = null;
            Color = ColorType.X; // Default value
        }
    }
}
