using CDb.Enums;

namespace CDb.Data.Model.Components
{
    public class DbHousing : DbComponent
    {   
        public string Description 
        { get; set; }
        public int RowCount 
        { get; set; }

        public DbHousing()
        {
            Description = string.Empty;
            RowCount = 0; // Default value
        }
    }
}
