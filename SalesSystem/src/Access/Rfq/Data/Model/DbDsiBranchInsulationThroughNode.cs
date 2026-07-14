namespace Rfq.Data.Model
{
    public class DbDsiBranchInsulationThroughNode : IAggregateRoot
    {
        public long RowId
        { get; set; }
        public string? PieceCode
        { get; set; }
        public double ThroughOrder
        { get; set; }
        public string? ThroughNode
        { get; set; }
        public string? ThroughRoute
        { get; set; }
        public bool IsThroughFlag
        { get; set; }
        public Guid HarnessId
        { get; set; }
        public DateTime CreatedDate
        { get; set; }
        public DateTime? ModifiedDate
        { get; set; }
        public Guid CreatedBy
        { get; set; }
        public Guid ModifiedBy
        { get; set; }
    }
}
