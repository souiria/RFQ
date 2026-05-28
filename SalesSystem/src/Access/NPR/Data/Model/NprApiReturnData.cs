namespace NPR.Data.Model
{
    public class NprApiReturnData
    {
        public string? RequestID
        { get; set; }

        public string? Error
        { get; set; }

        public Guid? Id
        { get; set; }

        public string? Name
        { get; set; }

        public string? OriginatorName
        { get; set; }

        public string? ReasonDescription
        { get; set; }

        public string? CustomerCode
        { get; set; }

        public string? ProjectCode
        { get; set; }

        public string? MaterialDescription
        { get; set; }

        public string? MaterialTypeDescription
        { get; set; }

        public string? ManufacturingSite
        { get; set; }

        public string? CustomerPartNumber
        { get; set; }

        public string? SupplierPartNumber
        { get; set; }

        public string? MaterialNumber
        { get; set; }

        public string? BOMUnitOfMeasurement
        { get; set; }

        public string? SupplierGroup
        { get; set; }

        public string? ManufacturerGroup
        { get; set; }

        public string? SupplierDetailComments
        { get; set; }

        public double? QtyPerVehicle
        { get; set; }

        public DateTime? DeadlineDate
        { get; set; }

        public string? NprRaisedRemarks
        { get; set; }

        public bool? IsCustomerNominatedSupplier
        { get; set; }

        public bool? IsCustomerNominatedMaterial
        { get; set; }

        public bool? IsSampleDataRequired
        { get; set; }
        public Collection<NprApiSampleSiteDetails>? SampleSiteDetails
        { get; }
        public string? AssociatedParts
        { get; set; }
        public string? SuggestedManufacturerGroup
        { get; set; }
        public string? CustomerRfqNo
        { get; set; }
    }
}
