using CDb.Enums;

namespace CDb.Data.Model.Components
{
    public class DbSupport : DbComponent
    {
        public string Description
        { get; set; }
        public string AdditionalInformation
        { get; set; }
        public ColorType Color
        { get; set; }

        public DbSupport()
        {
            // Initialize properties with default values
            Description = string.Empty;
            AdditionalInformation = string.Empty;
            Color = ColorType.X; // Default value
        }
    }
}
