namespace SharedModels.DocumentConverter.DSI
{
    public class PinMappingModel
    {
        public string? Node1 { get; set; }
        public string? Node2 { get; set; }
        public string? HarnessName1 { get; set; }
        public string? HarnessIssue1 { get; set; }
        public string? HarnessName2 { get; set; }
        public string? HarnessIssue2 { get; set; }
        public string? Separator { get; set; }
        public Guid? HarnessID { get; set; }
        public string? CavityMapping1 { get; set; }
        public string? CavityMapping2 { get; set; }
    }
}
