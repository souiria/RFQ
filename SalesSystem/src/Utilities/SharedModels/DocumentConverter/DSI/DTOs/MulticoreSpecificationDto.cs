namespace SharedModels.DocumentConverter.DSI.DTOs
{
    public class MulticoreSpecificationDto
    {
        public string? MulticoreName
        { get; set; }
        public bool? IsIncludedOnBom
        { get; set; }
        public bool? IsIncludedOnChart
        { get; set; }
        public string? Tag
        { get; set; }
        public string? Note
        { get; set; }
        public string? LengthChangeType
        { get; set; }
        public double? LengthChangeValue
        { get; set; }
        public string? OuterSheathCutBackAtEnd1Type
        { get; set; }
        public double? OuterSheathCutBackAtEnd1Value
        { get; set; }
        public string? OuterSheathCutBackAtEnd2Type
        { get; set; }
        public double? OuterSheathCutBackAtEnd2Value
        { get; set; }
        public string? Colour
        { get; set; }
        public string? Material
        { get; set; }
        public string? Specification
        { get; set; }
        public bool? IsSheathed
        { get; set; }
        public string? UserModule
        { get; set; }
        public double? AssemblyItemNumber
        { get; set; }
        public string? ParentMulticoreName
        { get; set; }
        public string? MulticoreOption
        { get; set; }
        public string? ParentMulticoreOption
        { get; set; }
        public double? UnmodifiedMulticoreLength
        { get; set; }
        public double? ModifiedMulticoreLength
        { get; set; }
        public string? PartNumber1
        { get; set; }
        public string? PartNumber2
        { get; set; }
        public string? PartNumber3
        { get; set; }
        public Guid? HarnessID
        { get; set; }
    }
}
