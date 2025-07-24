namespace SharedModels.DocumentConverter.DSI
{
    public class ModuleChildDetailModel
    {
        public string? ModuleCode { get; set; }
        public bool? IsCoreModule { get; set; }
        public string? HarnessName1 { get; set; }
        public string? SimilarHarnessName1 { get; set; }
        public string? HarnessIssue1 { get; set; }
        public string? SimilarHarnessIssue1 { get; set; }
        public DateTime? HarnessDate1 { get; set; }
        public string? HarnessName2 { get; set; }
        public string? SimilarHarnessName2 { get; set; }
        public string? HarnessIssue2 { get; set; }
        public string? SimilarHarnessIssue2 { get; set; }
        public DateTime? HarnessDate2 { get; set; }
        public string? Customer { get; set; }
        public string? Site { get; set; }
        public string? Range { get; set; }
        public double? BoardLength { get; set; }
        public double? BoardWidth { get; set; }
        public string? Datum { get; set; }
        public string? UserField1 { get; set; }
        public string? UserField2 { get; set; }
        public string? UserField3 { get; set; }
        public string? UserField4 { get; set; }
        public string? UserField5 { get; set; }
        public string? Checker { get; set; }
        public string? Inputter { get; set; }
        public string? DraftedBy { get; set; }
        public string? PreparedBy { get; set; }
        public string? Type { get; set; }
        public string? Title { get; set; }
        public string? EngineSize { get; set; }
        public string? ManufacturingCell { get; set; }
        public string? Trim { get; set; }
        public string? HandDrive { get; set; }
        public string? TubeAddOnType { get; set; }
        public double? TubeAddOnFactor { get; set; }
        public bool? IsManualTerminal { get; set; }
        public bool? IsAllConnectorSealed { get; set; }
        public string? AlphaCode { get; set; }
        public Guid? HarnessID { get; set; }
    }
}
