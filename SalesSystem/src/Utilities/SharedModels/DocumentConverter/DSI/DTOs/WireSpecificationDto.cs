namespace SharedModels.DocumentConverter.DSI.DTOs
{
    public class WireSpecificationDto
    {
        public string? WireName
        { get; set; }
        public string? CompositeOptionString
        { get; set; }
        public string? WireType
        { get; set; }
        public string? Colour
        { get; set; }
        public double? CrossSectionalArea
        { get; set; }
        public string? Material
        { get; set; }
        public string? UserModule
        { get; set; }
        public string? MulticoreName
        { get; set; }
        public string? End1NodeName
        { get; set; }
        public string? End1Route
        { get; set; }
        public string? End1Cavity
        { get; set; }
        public string? End1MaterialCode
        { get; set; }
        public string? End2NodeName
        { get; set; }
        public string? End2Route
        { get; set; }
        public string? End2Cavity
        { get; set; }
        public string? End2MaterialCode
        { get; set; }
        public bool? IsIncludedOnBom
        { get; set; }
        public bool? IsIncludedOnChart
        { get; set; }
        public string? WireTag
        { get; set; }
        public string? WireNote
        { get; set; }
        public string? WireLengthChangeType
        { get; set; }
        public double? WireLengthChangeValue
        { get; set; }
        public double? AssemblyItemNumber
        { get; set; }
        public string? MulticoreOption
        { get; set; }
        public double? UnmodifiedWireLength
        { get; set; }
        public double? ModifiedWireLength
        { get; set; }
        public double? CutbackAtEnd1
        { get; set; }
        public double? CutbackAtEnd2
        { get; set; }
        public string? PartNumber1
        { get; set; }
        public string? PartNumber2
        { get; set; }
        public string? PartNumber3
        { get; set; }
        public string? Signal
        { get; set; }
        public Guid? HarnessID
        { get; set; }
    }
}
