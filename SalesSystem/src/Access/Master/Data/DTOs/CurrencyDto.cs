namespace Master.Data.DTOs
{
    public class CurrencyDto
    {
        public required string? CurrencyCode { get; set; }
        public required string? CurrencyName { get; set; }
        public required string? EuroRate { get; set; }
        public required bool? IsActive { get; set; }
        public required Guid? Id { get; set; }
    }
}
