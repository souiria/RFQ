namespace Master.Data.Model
{
    public class DbSupplierGroup : IAggregateRoot
    {
        public string? SupplierGroupName
        { get; set; }
        public Guid? SupplierApprovalStatusGuid
        { get; set; }
        public Guid? SupplierPanelGuid
        { get; set; }
        public bool? IsActive 
        { get; set; }
        public bool? IsSWSPartNumberRequired
        { get; set; }
        public Guid? Id
        { get; set; }
        public DateTime? CreatedDate
        { get; set; }
        public DateTime? ModifiedDate
        { get; set; }
        public Guid? CreatedBy
        { get; set; }
        public Guid? ModifiedBy
        { get; set; }
        public short? SyncToCPD
        { get; set; }
        public bool? IsEOLRequired
        { get; set; }
    }
}
