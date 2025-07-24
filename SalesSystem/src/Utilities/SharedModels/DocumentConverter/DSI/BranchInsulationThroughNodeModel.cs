namespace SharedModels.DocumentConverter.DSI
{
    public class BranchInsulationThroughNodeModel
    {
        public string? PieceCode
        { get; set; }
        public double? ThroughOrder
        { get; set; }
        public string? ThroughNode
        { get; set; }
        public string? ThroughRoute
        { get; set; }
        public bool? IsThroughFlag
        { get; set; }
        public Guid? HarnessID
        { get; set; }
    }
}
