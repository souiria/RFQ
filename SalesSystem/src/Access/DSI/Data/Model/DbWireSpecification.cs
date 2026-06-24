namespace DSI.Data.Model
{
    public class DbWireSpecification : IAggregateRoot
    {
        public long RowId
        { get; set; }

        public string? WireName
        { get; set; }

        public string? WireType
        { get; set; }

        public string? Colour
        { get; set; }
        public string? CompositeOptionString
        { get; set; }
        public string? End1NodeName
        { get; set; }
        public string? End2NodeName
        { get; set; }

        public double? CrossSectionalArea
        { get; set; }

        public string? Material
        { get; set; }

        public bool? IsIncludedOnBom
        { get; set; }

        public bool? IsIncludedOnChart
        { get; set; }

        public string? WireTag
        { get; set; }

        public string? WireNote
        { get; set; }

        public double? UnmodifiedWireLength
        { get; set; }

        public double? ModifiedWireLength
        { get; set; }

        public string? PartNumber1
        { get; set; }

        public string? Signal
        { get; set; }

        public Guid? HarnessID
        { get; set; }

        public DateTime? CreatedDate
        { get; set; }

        public DateTime? ModifiedDate
        { get; set; }

        public Guid? CreatedBy
        { get; set; }

        public Guid? ModifiedBy
        { get; set; }
    }
}
