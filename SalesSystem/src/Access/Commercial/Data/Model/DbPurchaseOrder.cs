namespace Commercial.Data.Model
{
    public class DbPurchaseOrder : IAggregateRoot
    {
        public long Id 
        { get; set; }
        public string? MaterialNumber
        { get; set; }
        public string? SiteCode 
        { get; set; }
        public string? SupplierCode 
        { get; set; }
        public int? PORatio 
        { get; set; }
        public string? POUnit 
        { get; set; }
        public decimal? POPrice 
        { get; set; }
        public int? UnitConfacPO 
        { get; set; }
        public decimal? IndexedMaterialWeight 
        { get; set; }
        public decimal? IndexedMaterialRate 
        { get; set; }
        public decimal? POPriceExCopper 
        { get; set; }
        public string? ExternalDataSource 
        { get; set; }
        public string? CurrencyCode
        { get; set; }
        public DateTime? RaisedDate
        { get; set; }
        public long? SourceSystemTableId
        { get; set; }
        public string? IndexedMaterial
        { get; set; }
        public DateTime? ExpiryDate
        { get; set; }
        public decimal? ExchangeRate
        { get; set; }
        public string? CpdMaterialUom
        { get; set; }
        public string? CountryOfOriginCode
        { get; set; }
        public DateTime? CreateDate
        { get; set; }
        public decimal? CurrentExchangeRate
        { get; set; }
        public DateTime? ExchangeRateUpdateDate
        { get; set; }
    }
}
