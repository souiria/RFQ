namespace CDb.Data.Model.Components
{
    public class DbEyelet : DbComponent
    {
        public decimal StudSize
        { get; set; }
        public decimal Thickness
        { get; set; }
        public int Angle
        { get; set; }
        public bool IsWaterproof
        { get; set; }
        public bool IsCr6Free
        { get; set; }
        public string Family
        { get; set; }
        public string AdditionalInformation
        { get; set; }
        public PlatingType PlatingType
        { get; set; }

        public DbEyelet()
        {
            StudSize = 0;
            Thickness = 0.0m;
            Angle = 0;
            IsWaterproof = false;
            IsCr6Free = false;
            Family = string.Empty;
            AdditionalInformation = string.Empty;
            PlatingType = PlatingType.Undefined; // Default value
        }
    }
}
