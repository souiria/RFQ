namespace SharedModels.DocumentConverter.DSI.DTOs
{
    public class BranchConfigurationDto
    {
        public string? StartNode
        { get; set; }
        public string? StartRoute
        { get; set; }
        public string? StartCoordinates
        { get; set; }
        public string? EndNode
        { get; set; }
        public string? EndRoute
        { get; set; }
        public string? EndCoordinates
        { get; set; }
        public double? Length
        { get; set; }
        public Guid? CircuitOptionID
        { get; set; }
        public double? BundleDiameter
        { get; set; }
        public string? UserModule
        { get; set; }
        public string? AssignedModule
        { get; set; }
        public string? ModuleFrom
        { get; set; }
        public string? BendString
        { get; set; }
        public Guid? HarnessID
        { get; set; }
        public string? CircuitOption
        { get; set; }
        public string? Bend
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
