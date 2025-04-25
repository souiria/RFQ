namespace Master.Data.DTOs
{
    public class CustomerSalesEntityDto
    {
        public required string? CustomerSalesEntityCode { get; set; }
        public required string? CustomerSalesEntityName { get; set; }
        public required string? FinanceCode { get; set; }
        public required string? StreetNumber { get; set; }
        public required string? StreetName { get; set; }
        public required string? City { get; set; }
        public required string? Region { get; set; }
        public required string? ZipCode { get; set; }
        public required string? Country { get; set; }
        public required Guid? CustomerHierarchyGuid { get; set; }
        public required Guid? Id { get; set; }
        public required Guid? CustomerSalesCountryGuid { get; set; }
    }
}
