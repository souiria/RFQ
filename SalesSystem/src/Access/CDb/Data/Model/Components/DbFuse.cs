namespace CDb.Data.Model.Components
{
    public class DbFuse : DbComponent
    {
        public Guid? FuseTypeId
        { get; set; }
        public DbFuseType? FuseType
        { get; set; }
        public decimal Amperage
        { get; set; }
        public string Description
        { get; set; }
        public string AdditionalInfo
        { get; set; }
        public ColorType Color
        { get; set; }

        public DbFuse()
        {
            Amperage = 0.0m;
            Description = string.Empty;
            AdditionalInfo = string.Empty;
            Color = ColorType.X; // Default value
        }
    }
}
