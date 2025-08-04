namespace CDb.Data.Model.Masters
{
    public class DbTemperatureRange : IAggregateRoot
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
        public DbTemperatureRange(string temperatureRange, int temperatureLow, int temperatureHigh, bool isCustom)
        {
            Id = Guid.NewGuid();
            TemperatureRange = temperatureRange;
            TemperatureLow = temperatureLow;
            TemperatureHigh = temperatureHigh;
            IsCustom = isCustom;
            Components = new List<DbComponent>();
        }
    }
}
