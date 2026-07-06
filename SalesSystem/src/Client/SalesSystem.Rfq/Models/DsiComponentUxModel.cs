namespace SalesSystem.Rfq.Models
{
    public class DsiComponentUxModel
    {
        public long Id
        { get; set; }

        public string? NodeName
        { get; set; }

        public string? CavityName
        { get; set; }

        public string? WireName
        { get; set; }

        public string? SequenceNumber
        { get; set; }

        public string? ComponentTypeCode1
        { get; set; }

        public string? ComponentOption
        { get; set; }

        public string? ServiceFunction
        { get; set; }

        public string? Route
        { get; set; }

        public string? PartNumber1
        { get; set; }

        public string? PartNumber2
        { get; set; }

        public string? PartNumber3
        { get; set; }

        public double? Quantity
        { get; set; }

        public double? CrossSectionalArea
        { get; set; }

        public bool? IsSelectTerminal
        { get; set; }

        public bool? IsSeal
        { get; set; }

        public bool? IsPlugged
        { get; set; }

        public string? BlockNumber
        { get; set; }

        public string? TerminationMethod
        { get; set; }

        public string? MaterialCode
        { get; set; }

        public string? ComponentTypeCode2
        { get; set; }

        public string? InsulationType
        { get; set; }

        public string? UserModule
        { get; set; }

        public string? HarnessId
        { get; set; }

        public DateTime CreatedDate
        { get; set; } = DateTime.UtcNow;

        public DateTime ModifiedDate
        { get; set; } = DateTime.UtcNow;
    }
}
