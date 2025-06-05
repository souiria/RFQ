namespace Master.Data.DTOs
{
    public class CustomerSalesEntityDto
    {
        public string? CustomerSalesEntityCode
        { get; set; }
        public string? CustomerSalesEntityName
        { get; set; }
        public string? FinanceCode
        { get; set; }
        public string? StreetNumber
        { get; set; }
        public string? StreetName
        { get; set; }
        public string? City
        { get; set; }
        public string? Region
        { get; set; }
        public string? ZipCode
        { get; set; }
        public string? Country
        { get; set; }
        public Guid? CustomerHierarchyGuid
        { get; set; }
        public Guid? Id
        { get; set; }
        public Guid? CustomerSalesCountryGuid
        { get; set; }
        public bool? IsActive
        { get; set; }
    }
}
