namespace Master.Data.DTOs
{
    public class CustomerHierarchyDto
    {
        public required string? CustomerCode { get; set; }
        public required string? CustomerName { get; set; }
        public required string? StreetNumber { get; set; }
        public required string? StreetName { get; set; }
        public required string? City { get; set; }
        public required string? Region { get; set; }
        public required string? ZipCode { get; set; }
        public required string? Country { get; set; }
        public required string? CustomerBusinessType { get; set; }
        public required string? IndexedMaterial { get; set; }
        public required Guid? CustomerBusinessHierarchyGuid { get; set; }
        public required Guid? Id { get; set; }
        public required string? CustomerBusinessQualityManagerName { get; set; }
        public required Guid? CustomerCountryGuid { get; set; }
    }
}
