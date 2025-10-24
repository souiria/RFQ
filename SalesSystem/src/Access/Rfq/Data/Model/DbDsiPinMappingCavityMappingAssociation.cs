namespace Rfq.Data.Model
{
    public class DbDsiPinMappingCavityMappingAssociation : IAggregateRoot
    {
        public long RowId
        { get; set; }

        public Guid PinMappingID
        { get; set; }

        public Guid CavityMappingID
        { get; set; }

        public int MappingNumber
        { get; set; }

        public string? CreatedDate
        { get; set; }

        public string? ModifiedDate
        { get; set; }

        public string? CreatedBy
        { get; set; }

        public string? ModifiedBy
        { get; set; }
    }
}
