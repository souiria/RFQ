namespace Rfq.Data.Model
{
    public class DbRfqNprRequestModel : IAggregateRoot
    {
        /// <summary>H1 NPR id</summary>
        public Guid Id
        { get; set; }

        /// <summary>RFQ number (Free Text)</summary>
        [MaxLength(18)]
        public string? CustomerRfqNo
        { get; set; }

        /// <summary>Customer Code (Master)</summary>
        [MaxLength(18)]
        public string? CustomerCode
        { get; set; }

        /// <summary>NPR Request ID (Received in response)</summary>
        [MaxLength(18)]
        public string? RequestID
        { get; set; }

        /// <summary>NPR creator (Master)</summary>
        [MaxLength(100)]
        public string? OriginatorName
        { get; set; }

        /// <summary>Date Format yyyy-MM-dd</summary>
        public DateTime? DeadlineDate
        { get; set; }

        /// <summary>NPR Reason (Master)</summary>
        [MaxLength(50)]
        public string? ReasonDescription
        { get; set; }

        /// <summary>Material number (Free Text)</summary>
        [MaxLength(26)]
        public string? MaterialNumber
        { get; set; }

        /// <summary>Description (Free Text)</summary>
        [MaxLength(15)]
        public string? MaterialDescription
        { get; set; }

        /// <summary>CPN (Free Text)</summary>
        [MaxLength(26)]
        public string? CustomerPartNumber
        { get; set; }

        /// <summary>SPN (Free Text)</summary>
        [MaxLength(26)]
        public string? SupplierPartNumber
        { get; set; }

        /// <summary>Unit Of Measure (Master)</summary>
        [MaxLength(10)]
        public string? SEWSEUnitOfMeasurement
        { get; set; }

        /// <summary>Supplier Group (Master)</summary>
        [MaxLength(50)]
        public string? SupplierGroup
        { get; set; }

        /// <summary>Required if SupplierGroup has "New Supplier" (Free Text)</summary>
        [MaxLength(500)]
        public string? SupplierDetailComments
        { get; set; }

        /// <summary>Project (Master)</summary>
        [MaxLength(18)]
        public string? ProjectCode
        { get; set; }

        /// <summary>Qty</summary>
        public decimal? QtyPerVehicle
        { get; set; }

        /// <summary>Total Qty</summary>
        public int? VehicleTotalQuantity
        { get; set; }

        /// <summary>Flag</summary>
        public bool IsSampleDataRequired
        { get; set; }

        /// <summary>Required if IsSampleDataRequired is true. Array of sample sites</summary>
        public IEnumerable<RfqNprSampleSiteData>? SampleSiteDetails
        { get; set; }

        /// <summary>Remarks (Free Text)</summary>
        [MaxLength(500)]
        public string? NPRRaisedRemarks
        { get; set; }

        /// <summary>Site can be comma (,) separated in case of multiple sites (Master)</summary>
        public string? ManufacturingSite
        { get; set; }

        /// <summary>Flag</summary>
        public bool IsCustomerNominatedSupplier
        { get; set; }

        /// <summary>Flag</summary>
        public bool IsCustomerNominatedMaterial
        { get; set; }

        /// <summary>Platform (Master)</summary>
        [MaxLength(50)]
        public string? PlatformName
        { get; set; }

        /// <summary>Program (Master)</summary>
        [MaxLength(50)]
        public string? ProgramName
        { get; set; }

        /// <summary>Supplier Group (Master)</summary>
        [MaxLength(50)]
        public string? SuggestedManufacturerGroup
        { get; set; }

        /// <summary>YES/NO/UNKNOWN</summary>
        [MaxLength(50)]
        public string? AssociatedParts
        { get; set; }

        /// <summary>Serial number e.g. 1,2,3…</summary>
        public int? NPRUploadSeqNo
        { get; set; }
        public DateTime Created
        { get; set; }

        public DateTime Updated
        { get; set; }

        public int Status
        { get; set; }

        public bool IsActive
        { get; set; }

        public DateTime? Closed
        { get; set; }

        public string? Reason
        { get; set; }
    }
}
