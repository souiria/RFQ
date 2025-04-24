using SharedKernel;

namespace Master.Data.Model
{
    public class DbCustomerSalesEntity : IAggregateRoot
    {
        public string? CustomerSalesEntityCode { get; set; }
        public string? CustomerSalesEntityName { get; set; }
        public string? FinanceCode { get; set; }
        public string? StreetNumber { get; set; }
        public string? StreetName { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? ZipCode { get; set; }
        public string? Country { get; set; }
        public Guid? CustomerHierarchyGuid { get; set; }
        public Guid? Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }
        public bool? IsActive { get; set; }
        public short? SyncToCPD { get; set; }
        public Guid? CustomerSalesCountryGuid { get; set; }
    }
}
