namespace Master.Data.DTOs
{
    public class CustomerHierarchyDto
    {
        public string? CustomerCode
        { get; set; }
        public string? CustomerName
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
        public string? CustomerBusinessType
        { get; set; }
        public string? IndexedMaterial
        { get; set; }
        public Guid? CustomerBusinessHierarchyGuid
        { get; set; }
        public Guid? Id
        { get; set; }
        public string? CustomerBusinessQualityManagerName
        { get; set; }
        public Guid? CustomerCountryGuid
        { get; set; }
        public bool? IsActive
        { get; set; }
    }
}
