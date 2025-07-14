using CDb.Data.Model.Masters;

namespace CDb.Data.Model.Components
{
    public class DbMiscComponent : DbComponent
    {
        public Guid ComponentTypeId
        { get; set; }
        public DbMiscComponentType ComponentType
        { get; set; }
        public string? Dimension
        { get; set; }
        public string? AdditionaInfo
        { get; set; }
        public ColorType Color
        { get; set; }

        public DbMiscComponent()
        {
            // Initialize properties with default values
            ComponentType = null!;
            ComponentTypeId = Guid.Empty;
            Dimension = null;
            AdditionaInfo = null;
            Color = ColorType.X; // Default value
        }
    }
}
