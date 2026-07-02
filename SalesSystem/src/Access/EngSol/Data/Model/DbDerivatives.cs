namespace EngSol.Data.Model
{
    public class DbDerivatives : IAggregateRoot
    {
        public int CompositeId
        { get; set; }
        public int DerivativeId
        { get; set; }
        public string? IHSDerivativePartNumber
        { get; set; }
        public string? DerivativeName
        { get; set; }
        public byte? DrawingChangeControlStatus
        { get; set; }
        public string? HarnessType
        { get; set; }
        public DateTime? ExpiryDate
        { get; set; }
        public int? WireCount
        { get; set; }
        public short? MultiCoreLeadGroupCount
        { get; set; }
        public short? TwistedLeadGroupCount
        { get; set; }
        public short? MultiCoreInnerCoreLeadsCount
        { get; set; }
        public bool? DerivativeUploadStatusFlag
        { get; set; }
    }
}
