using CDb.Enums;

namespace CDb.Data.Model.Components
{
    public class DbDiode : DbComponent
    {
        public decimal Amperage 
        { get; set; }
        public string Description 
        { get; set; }
        public string AdditionalInformation 
        { get; set; }
        public ColorType Color 
        { get; set; }

        public DbDiode() 
        {
            Amperage = 0;
            Description = string.Empty;
            AdditionalInformation = string.Empty;
        }
    }
}
