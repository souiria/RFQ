namespace CDb.Data.Model.Components
{
    public class DbCover : DbComponent
    {
        public Guid? CoverTypeId
        { get; set; }
        public DbCoverType? CoverType
        { get; set; }
        public decimal Diameter
        { get; set; }
        public decimal Length
        { get; set; }
        public decimal Width
        { get; set; }
        public string Function
        { get; set; }
        public bool HasNoiseDampening
        { get; set; }
        public bool IsTearable
        { get; set; }
        public bool IsPreCut
        { get; set; }
        public string AdditionalInformation
        { get; set; }
        public ColorType Color
        { get; set; }

        public DbCover()
        {
            CoverTypeId = Guid.Empty;
            Diameter = 0;
            Function = string.Empty;
            AdditionalInformation = string.Empty;
            Length = 0;
            Width = 0;
        }
    }
}
