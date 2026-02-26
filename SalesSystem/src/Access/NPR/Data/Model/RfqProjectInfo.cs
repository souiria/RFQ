namespace NPR.Data.Model
{
    public class RfqProjectInfo
    {
        public long RowId
        { get; set; }
        public string RfqNumber
        { get; set; }
        public string CustomerBusinessUnitId
        { get; set; }
        public string? CustomerBusinessUnit
        { get; set; }
        public string CustomerLocationId
        { get; set; }
        public string? CustomerLocation
        { get; set; }
        public string ProjectId
        { get; set; }
        public string? Project
        { get; set; }
        public int RfqReasonId
        { get; set; }
        public string? RfqReason
        { get; set; }
        public DateTime? RfqResponseDeadline
        { get; set; }
        public string CarModelId
        { get; set; }
        public string? CarModel
        { get; set; }
        public int VehicleVolume
        { get; set; }
        public bool IsActive
        { get; set; }
        public RfqProjectInfo()
        {
            RfqNumber = string.Empty;
            CustomerBusinessUnitId = string.Empty;
            CustomerLocationId = string.Empty;
            ProjectId = string.Empty;
            CarModelId = string.Empty;
            VehicleVolume = 0;
            ProjectId = string.Empty;
            RfqReasonId = 0;
            IsActive = false;
        }
    }
}
