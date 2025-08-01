namespace SharedModels.DocumentConverter.DSI.DTOs
{
    public class ManualBomQuantityDto
    {
        public string? SplitValue
        { get; set; }
        public string? ModuleCode
        { get; set; }
        public double? Percentage
        { get; set; }
        public Guid? HarnessID
        { get; set; }
    }
}
