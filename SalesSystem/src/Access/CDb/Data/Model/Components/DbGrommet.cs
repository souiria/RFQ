using CDb.Enums;

namespace CDb.Data.Model.Components
{
    public class DbGrommet : DbComponent
    {
        public string Location 
        { get; set; }
        public string AdditionalInformation 
        { get; set; }
        public ColorType Color 
        { get; set; }

        public DbGrommet()
        {
            Location = string.Empty;
            AdditionalInformation = string.Empty;
            Color = ColorType.X; // Default value
        }
    }
}
