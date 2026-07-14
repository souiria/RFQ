namespace SharedModels.DocumentConverter.DSI.DTOs
{
    public class ModuleCompatibilityDto
    {
        public string? ModuleCode1
        { get; set; }
        public string? ModuleCode2
        { get; set; }
        public string? Relationship
        { get; set; }
        public Guid? HarnessID
        { get; set; }
    }
}
