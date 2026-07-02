namespace EngSol.Data.Model
{
    public class DbDerivativeParts : IAggregateRoot
    {
        public int DerivativeId 
        { get; set; }
        public string? PartNumber 
        { get; set; }
        public string? PartDescription
        { get; set; }
        public int? PartQuantity
        { get; set; }
        public double? PartLength
        { get; set; }
        public string? PartSlit
        { get; set; }
        public string? PartClass
        { get; set; }
    }
}
