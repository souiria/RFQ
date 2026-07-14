namespace Master.Data.DTOs
{
    public class SupplierGroupDto
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
    }
}
