namespace CDb.Data.Model.Components
{
    public class DbConnector : DbComponent
    {
        public Guid? WaterproofTypeId
        { get; set; }
        public DbWaterproofType? WaterproofType
        { get; set; }
        public MatingType MatingType
        { get; set; }
        public decimal CavitySize
        { get; set; }
        public int CavityCount
        { get; set; }
        public bool IsHybrid
        { get; set; }
        public bool IsModule
        { get; set; }
        public Guid? TerminalFamilyId
        { get; set; }
        public DbTerminalFamily? TerminalFamily
        { get; set; }
        public Guid? TerminalSizeId
        { get; set; }
        public DbTerminalSize? TerminalSize
        { get; set; }
        public string? AdditionalInformation
        { get; set; }
        public ColorType Color
        { get; set; }

        public DbConnector()
        {
            WaterproofTypeId = null;
            TerminalFamilyId = null;
            TerminalSizeId = null;
            AdditionalInformation = null;
        }
    }
}
