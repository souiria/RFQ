namespace CDb.Data.Model.Masters
{
    public class DbTemperatureRange
    {
        public Guid Id 
        { get; set; }
        public string TemperatureRange 
        { get; set; }
        public int TemperatureLow 
        { get; set; }
        public int TemperatureHigh 
        { get; set; }
        public bool IsCustom 
        { get; set; }

        public ICollection<DbComponent> Components 
        { get; init; }

        public DbTemperatureRange()
        {
            Id = Guid.NewGuid();
            TemperatureRange = string.Empty;
            TemperatureLow = 0;
            TemperatureHigh = 0;
            IsCustom = false;
            Components = new List<DbComponent>();
        }
    }
}
