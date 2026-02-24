namespace SalesSystem.Rfq.Models
{
    public class RfqNprRequestUxModel
    {
        #region Properties

        public Guid Id
        { get; set; }

        public string? RfqNumber
        { get; set; }

        public DateTime Created
        { get; set; }

        public DateTime Updated
        { get; set; }

        public RfqNprRequestSet Status
        { get; set; }
        public UxObjectStatus UxStatus
        { get; set; }

        public DateTime? Closed
        { get; set; }

        public string? Reason
        { get; set; }

        public string? Customer
        { get; set; }

        public string? PlatformName
        { get; set; }

        public string? ProgramName
        { get; set; }

        public string? Project
        { get; set; }

        public string? MaterialType
        { get; set; }

        public string? SuggestedSewsEManufacturingSite
        { get; set; }

        public string? CustomerPartNumber
        { get; set; }

        public string? SupplierPartNumber
        { get; set; }

        public string? SumitomoNumber
        { get; set; }

        public string? MaterialDescription
        { get; set; }

        public string? UnitOfMeasure
        { get; set; }

        public string? SupplierGroup
        { get; set; }

        public int? QtyPerVehicle
        { get; set; }

        public int? Quantity
        { get; set; }

        public DateTime? RequiredDate
        { get; set; }

        public string? RaisedRemarks
        { get; set; }

        public bool IsCustomerNominatedSupplier
        { get; set; }

        public bool IsCustomerNominatedMaterial
        { get; set; }

        public bool SamplesRequired
        { get; set; }

        public string? SampleSite
        { get; set; }

        public int? SampleQuantity
        { get; set; }

        public string? SampleRecipient
        { get; set; }

        public DateTime? SampleRequiredDate
        { get; set; }

        public string? FreightAccount
        { get; set; }

        public string? AssociatedParts
        { get; set; }

        public string? SuggestedManufacturer
        { get; set; }

        #endregion

        #region Constructors

        public RfqNprRequestUxModel()
        {
            Id = Guid.NewGuid();
            Status = RfqNprRequestSet.Draft;
            UxStatus = UxObjectStatus.Created;
        }

        #endregion
    }
}