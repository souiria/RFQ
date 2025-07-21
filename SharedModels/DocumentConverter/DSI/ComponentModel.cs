namespace SharedModels.DocumentConverter.DSI
{
    public class ComponentModel
    {
        public string? NodeName { get; set; }
        public string? CavityName { get; set; }
        public string? WireName { get; set; }
        public string? SequenceNumber { get; set; }
        public string? ComponentTypeCode1 { get; set; }
        public string? ComponentOption { get; set; }
        public string? ServiceFunction { get; set; }
        public string? Route { get; set; }
        public string? PartNumber1 { get; set; }
        public string? PartNumber2 { get; set; }
        public string? PartNumber3 { get; set; }
        public double? Quantity { get; set; }
        public double? CrossSectionalArea { get; set; }
        public bool? IsSelectTerminal { get; set; }
        public bool? IsSeal { get; set; }
        public bool? IsPlugged { get; set; }
        public string? BlockNumber { get; set; }
        public string? TerminationMethod { get; set; }
        public string? MaterialCode { get; set; }
        public string? ComponentTypeCode2 { get; set; }
        public string? InsulationType { get; set; }
        public string? UserModule { get; set; }
        public string? AssignedModule { get; set; }
        public string? ModuleFrom { get; set; }
        public string? SplitValue { get; set; }
        public string? Datum { get; set; }
        public double? AssemblyItemNumber { get; set; }
        public string? ColourCode { get; set; }
        public double? NumberOfCavities { get; set; }
        public bool? IsBackshell { get; set; }
        public string? WireOption { get; set; }
        public Guid? HarnessID { get; set; }
    }
}
