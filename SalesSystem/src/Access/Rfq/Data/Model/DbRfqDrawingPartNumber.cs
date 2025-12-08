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
        string? _SumitomoPartNumber;
        public string SumitomoPartNumber
        {
            get => string.IsNullOrEmpty(_SumitomoPartNumber) ? "0000000" : _SumitomoPartNumber;
            set => _SumitomoPartNumber = string.IsNullOrEmpty(value) ? "0000000" : value;
        }
         string? _SupplierPartNumber;
        public string SupplierPartNumber
        {
            get => string.IsNullOrEmpty(_SupplierPartNumber) ? "0000000" : _SupplierPartNumber;
            set => _SupplierPartNumber = string.IsNullOrEmpty(value) ? "0000000" : value;
        }
        public Guid? NprId
        { get; set; }
        public string? CustomerPartNumber
        { get; set; }
        public string? NprRequest
        { get; set; }
        public DbRfqProject? RfqProject
        { get; set; }
    }
}
