namespace Master.Data.Model
{
    public class DbSupplier : IAggregateRoot
    {
        public string? SupplierCode
        { get; set; }
        public string? SupplierName
        { get; set; }
        public string? Address1
        { get; set; }
        public string? Address2
        { get; set; }
        public string? Address3
        { get; set; }
        public string? City
        { get; set; }
        public string? Region
        { get; set; }
        public string? ZipCode
        { get; set; }
        public Guid? CountryGuid
        { get; set; }
        public Guid? SupplierTypeGuid
        { get; set; }
        public Guid? SupplierGroupGuid
        { get; set; }
        public Guid? SupplierIncoTermsGuid
        { get; set; }
        public Guid? SupplierCurrencyGuid
        { get; set; }
        public Guid? SupplierBuyerGuid
        { get; set; }
        public Guid? SupplierDevelopmentTeamGuid
        { get; set; }
        public string? PaymentTerms
        { get; set; }
        public Guid? EPOCommodityGroupGuid
        { get; set; }
        public Guid? POPriceEffectiveDateTypeGuid
        { get; set; }
        public Guid? SupplierApprovalStatusGuid
        { get; set; }
        public bool? IsActive
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
        public Guid? DistributionCountryOfOriginGuid
        { get; set; }
        public bool? IsEOLRequired
        { get; set; }
    }
}
