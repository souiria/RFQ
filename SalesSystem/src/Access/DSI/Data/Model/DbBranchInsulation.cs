namespace DSI.Data.Model
{
    public class DbBranchInsulation : IAggregateRoot
    {
        public Guid Id
        { get; set; }

        public string? StartNode
        { get; set; }

        public string? EndNode
        { get; set; }

        public string? PieceCode
        { get; set; }

        public string? InsulationCode
        { get; set; }

        public double? Diameter
        { get; set; }

        public Guid? CircuitOptionID
        { get; set; }

        public double? ManualAmount
        { get; set; }

        public string? PartNumber1
        { get; set; }

        public bool? IsConvoluted
        { get; set; }

        public bool? IsSlit
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
