namespace Rfq.Data.Model
{
    public class DbRfqDrawingPartNumber : IAggregateRoot
    {
        public long RowId
        { get; set; }
        public long RfqId
        { get; set; }
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
        public string? Comments
        { get; set; }
        public DbRfqProject? RfqProject
        { get; set; }
    }
}
