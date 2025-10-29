using System;

namespace SalesSystem.Rfq.Models
{
    public class RfqProjectUx
    {
        public long RowId
        { get; set; }
        public string RfqNumber
        { get; set; }
        public Guid CustomerBusinessUnitGuid
        { get; set; }
        public string? CustomerBusinessUnit
        { get; set; }
        public Guid CustomerLocationGuid
        { get; set; }
        public string? CustomerLocation
        { get; set; }
        public Guid ProjectGuid
        { get; set; }
        public string? Project
        { get; set; }
        public int RfqReasonId
        { get; set; }
        public string? RfqReason
        { get; set; }
        public DateTime? RfqResponseDeadline
        { get; set; }
        public Guid CarModelGuid
        { get; set; }
        public string? CarModel
        { get; set; }
        public int VehicleVolume
        { get; set; }
        public RfqProjectUx()
        {
            RfqNumber = string.Empty;
            CustomerBusinessUnitGuid = Guid.Empty;
            CustomerLocationGuid = Guid.Empty;
            ProjectGuid = Guid.Empty;
            CarModelGuid =  Guid.Empty;
            VehicleVolume = 0;
        }
    }
}
