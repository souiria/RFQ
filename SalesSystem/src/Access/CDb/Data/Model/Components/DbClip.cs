using CDb.Data.Model.Masters;

namespace CDb.Data.Model.Components
{
    public class DbClip : DbComponent
    {
        public Guid ClipTypeId
        { get; set; }
        public DbClipType ClipType
        { get; set; }
        public TieType TieType
        { get; set; }
        public string DimensionCode
        { get; set; }
        public string ThicknessCode
        { get; set; }
        public decimal Length
        { get; set; }
        public bool IsDoubleHarness
        { get; set; }
        public int ClipOrientationStart
        { get; set; }
        public int ClipOrientationEnd
        { get; set; }
        public string? AdditionalInfo
        { get; set; }

        public DbClip() : base()
        {
            ClipType = null!;
            ClipTypeId = Guid.Empty;
            TieType = TieType.Unknown; // Default to "Unknown"
            DimensionCode = string.Empty;
            ThicknessCode = string.Empty;
            Length = 0.0m;
            IsDoubleHarness = false;
            ClipOrientationStart = 0;
            ClipOrientationEnd = 0;
            AdditionalInfo = string.Empty;
        }
    }
}