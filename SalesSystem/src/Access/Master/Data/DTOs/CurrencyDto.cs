namespace Master.Data.DTOs
{
    public class CurrencyDto
    {
        public string? CurrencyCode
        { get; set; }
        public string? CurrencyName
        { get; set; }
        public string? EuroRate
        { get; set; }
        public bool? IsActive
        { get; set; }
        public Guid? Id
        { get; set; }
    }
}
