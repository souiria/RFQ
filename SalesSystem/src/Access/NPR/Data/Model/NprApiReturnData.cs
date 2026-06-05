namespace NPR.Data.Model
{
    public class NprApiReturnData
    {
        [JsonProperty("requestID")]
        public string? RequestID 
        { get; set; }

        [JsonProperty("error")]
        public string? Error 
        { get; set; }

        [JsonProperty("id")]
        public Guid? Id 
        { get; set; }

        [JsonProperty("name")]
        public string? Name 
        { get; set; }

        [JsonProperty("originatorName")]
        public string? OriginatorName 
        { get; set; }

        [JsonProperty("reasonDescription")]
        public string? ReasonDescription
        { get; set; }

        [JsonProperty("customerCode")]
        public string? CustomerCode
        { get; set; }

        [JsonProperty("platformName")]
        public string? PlatformName
        { get; set; }

        [JsonProperty("programName")]
        public string? ProgramName
        { get; set; }

        [JsonProperty("projectCode")]
        public string? ProjectCode 
        { get; set; }

        [JsonProperty("materialDescription")]
        public string? MaterialDescription 
        { get; set; }

        [JsonProperty("manufacturingSite")]
        public string? ManufacturingSite 
        { get; set; }

        [JsonProperty("customerPartNumber")]
        public string? CustomerPartNumber 
        { get; set; }

        [JsonProperty("supplierPartNumber")]
        public string? SupplierPartNumber
        { get; set; }

        [JsonProperty("materialNumber")]
        public string? MaterialNumber 
        { get; set; }

        [JsonProperty("sewseUnitOfMeasurement")]
        public string? SEWSEUnitOfMeasurement 
        { get; set; }

        public string? SupplierGroup 
        { get; set; }

        public string? ManufacturerGroup 
        { get; set; }

        [JsonProperty("supplierDetailComments")]
        public string? SupplierDetailComments 
        { get; set; }

        [JsonProperty("qtyPerVehicle")]
        public string? QtyPerVehicle 
        { get; set; }

        [JsonProperty("vehicleTotalQuantity")]
        public string? VehicleTotalQuantity 
        { get; set; }

        [JsonProperty("deadlineDate")]
        public DateTime? DeadlineDate
        { get; set; }

        [JsonProperty("nprRaisedRemarks")]
        public string? NprRaisedRemarks 
        { get; set; }

        [JsonProperty("isCustomerNominatedSupplier")]
        public string? IsCustomerNominatedSupplier 
        { get; set; }

        [JsonProperty("isCustomerNominatedMaterial")]
        public string? IsCustomerNominatedMaterial
        { get; set; }

        [JsonProperty("isSampleDataRequired")]
        public string? IsSampleDataRequired 
        { get; set; }

        [JsonProperty("sampleSiteDetails")]
        public Collection<NprApiSampleSiteDetails> SampleSiteDetails 
        { get; } = new();  // initialized, no setter

        [JsonProperty("associatedParts")]
        public string? AssociatedParts 
        { get; set; }

        [JsonProperty("suggestedManufacturerGroup")]
        public string? SuggestedManufacturerGroup 
        { get; set; }

        [JsonProperty("customerRfqNo")]
        public string? CustomerRfqNo 
        { get; set; }
    }
}
