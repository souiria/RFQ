namespace SalesSystem.Rfq.Models
{
    public class RfqPartNumberExportModel
    {
        public long RowId 
        { get; set; }
        public long RfqId 
        { get; set; }
        public string Category 
        { get; set; } = string.Empty; // "Matched" or "Unmatched"
        public string? OriginalPartNumber 
        { get; set; }
        public decimal? OriginalPartNumberPrice 
        { get; set; }
        public string? SwappedPartNumber 
        { get; set; }
        public decimal? SwappedPartNumberPrice 
        { get; set; }
        public string? PriceSource 
        { get; set; }
        public bool? IsExactMatch 
        { get; set; }
        public bool? IsSwapped 
        { get; set; }
        public bool IsMatched 
        { get; set; }
        public bool MultiMatch 
        { get; set; }
        public decimal? PriceDifference 
        { get; set; }
        public string? Comments 
        { get; set; }
    }
}