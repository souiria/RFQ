namespace DSI.Data.Model
{
    public class DbComponent : IAggregateRoot
    {
        public Guid Id
        { get; set; }

        public string? NodeName
        { get; set; }

        public string? CavityName
        { get; set; }

        public string? WireName
        { get; set; }

        public string? SequenceNumber
        { get; set; }

        public string? ComponentOption
        { get; set; }

        public string? Route
        { get; set; }

        public string? PartNumber1
        { get; set; }

        public double? Quantity
        { get; set; }

        public double? CrossSectionalArea
        { get; set; }

        public bool? IsPlugged
        { get; set; }

        public string? MaterialCode
        { get; set; }

        public string? InsulationType
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
