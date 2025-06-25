using SharedKernel;

namespace Master.Data.Model
{
    public class DbCurrency : IAggregateRoot
    {
        public string? CurrencyCode
        { get; set; }
        public string? CurrencyName
        { get; set; }
        public string? EuroRate
        { get; set; }
        public bool IsActive
        { get; set; }
        public Guid? Id
        { get; set; }
        public DateTime? CreatedDate
        { get; set; }
        public DateTime? ModifiedDate
        { get; set; }
        public Guid? CreatedBy
        { get; set; }
        public Guid? ModifiedBy
        { get; set; }
        public short? SyncToCPD
        { get; set; }
        public bool? IsExchangeRequired
        { get; set; }
    }
}
