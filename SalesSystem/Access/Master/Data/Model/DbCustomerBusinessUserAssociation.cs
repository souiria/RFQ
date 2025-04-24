using SharedKernel;

namespace Master.Data.Model
{
    public class DbCustomerBusinessUserAssociation : IAggregateRoot
    {
        public Guid? UserGuid { get; set; }
        public string? CustomerBusinessHierarchyList { get; set; }
        public Guid? Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }
        public bool? IsActive { get; set; }
    }
}
