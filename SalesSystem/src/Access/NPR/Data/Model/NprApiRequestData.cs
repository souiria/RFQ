namespace NPR.Data.Model
{
    public class NprApiRequestData
    {
        public string? CustomerRfqNo
        { get; set; }
        public string? CustomerCode
        { get; set; }
        public string? RequestID
        { get; set; }
        public string? OriginatorName
        { get; set; }
        public DateOnly? DeadlineDate
        { get; set; }
        public string? ReasonDescription
        { get; set; }
        public string? MaterialNumber
        { get; set; }
        public string? MaterialDescription
        { get; set; }
        public string? MaterialTypeDescription
        { get; set; }
        public string? CustomerPartNumber
        { get; set; }
        public string? SupplierPartNumber
        { get; set; }
        public string? SEWSEUnitOfMeasurement
        { get; set; }
        public string? SupplierGroup
        { get; set; }
        public string? SupplierDetailComments
        { get; set; }
        public string? ProjectCode
        { get; set; }
        public double? QtyPerVehicle
        { get; set; }
        public int? VehicleTotalQuantity
        { get; set; }
        public bool? IsSampleDataRequired
        { get; set; }
        public IEnumerable<SampleSiteDetailsGrpc>? SampleSiteDetails
        { get; set; }
        public string? NPRRaisedRemarks
        { get; set; }
        public string? ManufacturingSite
        { get; set; }
        public bool? IsCustomerNominatedSupplier
        { get; set; }
        public bool? IsCustomerNominatedMaterial
        { get; set; }
        public string? PlatformName
        { get; set; }
        public string? ProgramName
        { get; set; }
        public string? SuggestedManufacturerGroup
        { get; set; }
        public string? AssociatedParts
        { get; set; }
        public int? NPRUploadSeqNo
        { get; set; }
    }
}
