// version History:
// 1.0 - Initial development - NPR_RFQ_API_Documentation_v1.pdf - 20260415
// 1.2 - Added new fields and properties - NPR_RFQ_API_Documentation_v1.2.pdf - 20260416
//       Data model changes:
//           SupplierRfqNo field renamed to CustomerRfqNo to better reflect its meaning
// 1.3 - Source data change and Master Field Description - NPR_RFQ_API_Documentation_v1.3.pdf - 20260416
//       Data model metadata tweaks:
//           OriginatorName description changed from "ADCommonName" to "Master"
//           ManufacturingSite marked as "Master"
// v 2.0 - Remove fields and properties - NPR_RFQ_API_Documentation_v2.0.pdf - 20240610
//          Replace SEWSEUnitOfMeasurement with BOMUnitOfMeasurement
//          Remove RequestID from request payload
//          Remove VehicleTotalQuantity
//          Remove PlatformName
//          Remove ProgramName

namespace SalesSystem.Rfq.Models
{
    public class ValidationError
    {
        public string FieldName
        { get; set; }
        public string CurrentValue
        { get; set; }
        public string Message
        { get; set; }

        public ValidationError()
        {
            FieldName = string.Empty;
            CurrentValue = string.Empty;
            Message = string.Empty;
        }

        public ValidationError(string fieldName, string currentValue, string message)
        {
            FieldName = fieldName;
            CurrentValue = currentValue;
            Message = message;
        }
    }

    public class RfqNprRequestUxModel
    {
        #region API Properties

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
        public string? BOMUnitOfMeasurement
        { get; set; }

        /// <summary>Supplier Group (Master)</summary>
        [MaxLength(50)]
        public string? SupplierGroup
        { get; set; }

        /// <summary>Required if SupplierGroup has "New Supplier" (Free Text)</summary>
        [MaxLength(500)]
        public string? SupplierDetailComments
        { get; set; }

        /// <summary>ProjectName (Master)</summary>
        [MaxLength(18)]
        public string? ProjectCode
        { get; set; }

        /// <summary>Qty</summary>
        public decimal? QtyPerVehicle
        { get; set; }

        /// <summary>Total Qty</summary>
        //public int? VehicleTotalQuantity
        //{ get; set; }

        /// <summary>Flag</summary>
        public bool IsSampleDataRequired
        { get; set; }

        /// <summary>Required if IsSampleDataRequired is true. Array of sample sites</summary>
        public Collection<RfqNprRequestSampleSiteDataUxModel> SampleSiteDetails
        { get; } = new Collection<RfqNprRequestSampleSiteDataUxModel>();

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
        //[MaxLength(50)]
        //public string? PlatformName
        //{ get; set; }

        /// <summary>Program (Master)</summary>
        //[MaxLength(50)]
        //public string? ProgramName
        //{ get; set; }

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

        public Guid CreatedBy
        { get; set; }

        public Guid ModifiedBy
        { get; set; }

        public DateTime? SubmittedAt
        { get; set; }

        public DateTime? Closed
        { get; set; }

        public  string? Reason
        { get; set; }
        public DateTime Created
        { get; set; }

        public DateTime Updated
        { get; set; }

        public int Status
        { get; set; }

        public string StatusName
        { get; set; }
        #endregion

        #region Local Properties
        UxObjectStatus _UxStatus;
        public UxObjectStatus UxStatus
        {
            get
            {
                return _UxStatus;
            }
            set
            {
                if (_UxStatus != value)
                {
                    _UxStatus = value;
                    if (_UxStatus == UxObjectStatus.Deleted)
                    {
                        _IsActive = false;
                    }
                    else
                    {
                        _IsActive = true;
                    }
                }
            }
        }

        bool _IsActive;
        public bool IsActive => _IsActive;

        bool _IsValid;
        public bool IsValid
        {
            get
            {
                return Validate();
            }
        }

        Dictionary<string, ValidationError> _ValidationErrors;
        public Dictionary<string, ValidationError> ValidationErrors
        {
            get
            {
                return _ValidationErrors;
            }
        }

        int _ErrorCount;
        public int ErrorCount => _ErrorCount;

        #endregion

        #region Constructors

        public RfqNprRequestUxModel()
        {
            Id = Guid.NewGuid();
            AssociatedParts = "NO";
            Status = 0;
            StatusName = "";
            UxStatus = UxObjectStatus.Created;
            SampleSiteDetails = new Collection<RfqNprRequestSampleSiteDataUxModel>();
            Created = DateTime.UtcNow;
            Updated = DateTime.UtcNow;
            _IsValid = false;
            _ValidationErrors = new Dictionary<string, ValidationError>();
            _ErrorCount = 0;
        }

        #endregion

        #region Validator
        void Err(string fieldName, string currentValue, string message)
        {
            _ValidationErrors[fieldName] = new ValidationError(fieldName, currentValue, message);
            _ErrorCount++;
        }

        public bool Validate()
        {
            _IsValid = false;    
            _ValidationErrors.Clear();
            _ErrorCount = 0;

            //// -----------------------------
            //// REQUIRED FIELD VALIDATIONS
            //// -----------------------------
            if (Id == Guid.Empty)
            {
                Err(nameof(Id), Id.ToString(), "Id is required.");
            }

            if (string.IsNullOrWhiteSpace(CustomerRfqNo))
            {
                Err(nameof(CustomerRfqNo), CustomerRfqNo ?? "", "Customer is required.");
            }

            if (string.IsNullOrWhiteSpace(CustomerCode))
            {
                Err(nameof(CustomerCode), CustomerCode ?? "", "Customer can not be blank");
            }
            else
            {

                if (18 < CustomerCode.Length)
                {
                    Err(nameof(CustomerCode),
                        CustomerCode, "CustomerCode exceeds maximum length of 18 characters");
                }
            }

            if (!string.IsNullOrWhiteSpace(RequestID))
            {
                Err(nameof(RequestID),
                    RequestID, "NPR Request already registered, existing RequestID!");
            }

            if (string.IsNullOrWhiteSpace(ManufacturingSite))
            {
                Err(nameof(ManufacturingSite), ManufacturingSite ?? "", "ManufacturingSite is required.");
            }

            if (string.IsNullOrWhiteSpace(OriginatorName))
            {
                Err(nameof(OriginatorName), OriginatorName ?? "", "Originator Name is required");
            }

            if (DeadlineDate == null)
            {
                Err(nameof(DeadlineDate), "",
                    "DeadlineDate can not be blank, and should be greater than today's date");
            }
            else
            {
                DateTime today = DateTime.UtcNow.Date;
                DateTime deadlineDate = DeadlineDate.Value.Date;

                // covers past + today
                if (DeadlineDate <= today)
                {
                    Err(nameof(DeadlineDate), deadlineDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                        "DeadlineDate should be greater than today's date");
                }

                DateTime created = Created.Date;

                if (deadlineDate < created)
                {
                    Err(nameof(DeadlineDate), created.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) ?? "",
                        "DeadlineDate should be greater than creation's date");
                }
            }

            if (string.IsNullOrWhiteSpace(ReasonDescription))
            {
                Err(nameof(ReasonDescription), ReasonDescription ?? "",
                    "Reason Description is required.");
            }
            else
            {
                if (50 < ReasonDescription.Length)
                {
                    Err(nameof(ReasonDescription), ReasonDescription,
                        "Reason Description can not be greater than 50 characters.");
                }
            }

            if (string.IsNullOrWhiteSpace(MaterialNumber))
            {
                Err(nameof(MaterialNumber), MaterialNumber ?? "",
                    "MaterialNumber Can not be blank!");
            }
            else
            {
                if (MaterialNumber.Length > 8)
                {
                    Err(nameof(MaterialNumber), MaterialNumber,
                        "MaterialNumber must more than 8 characters");
                }
            }

            if (string.IsNullOrWhiteSpace(MaterialDescription))
            {
                Err(nameof(MaterialDescription), MaterialDescription ?? "",
                    "MaterialDescription Can not be blank!");
            }
            else
            {

                if (MaterialDescription.Length < 1 || 15 < MaterialDescription.Length)
                {
                    Err(nameof(MaterialDescription), MaterialDescription,
                        "Material Description Can not be less than 1 and greater than 15 characters.");
                }
            }

            if (string.IsNullOrWhiteSpace(CustomerPartNumber))
            {
                Err(nameof(CustomerPartNumber), CustomerPartNumber ?? "", "Customer part number is required.");
            }

            string supplierPartNumber = SupplierPartNumber ?? string.Empty;
            string materialNumber = MaterialNumber ?? string.Empty;

            bool hasSupplierPartNumber = !string.IsNullOrWhiteSpace(supplierPartNumber);
            bool hasMaterialNumber = !string.IsNullOrWhiteSpace(materialNumber);

            if (!hasMaterialNumber && !hasSupplierPartNumber)
            {
                Err("MaterialNumber,SupplierPartNumber", $"MaterialNumber: {MaterialNumber ?? ""}, SupplierPartNumber: {SupplierPartNumber ?? ""}",
                    "Provide either the Material Number or the Supplier Part Number.");
            }

            if (!hasMaterialNumber && !hasSupplierPartNumber)
            {
                Err(nameof(SupplierPartNumber), SupplierPartNumber ?? "",
                    "Supplier Part number cannot be blank");
            }

            string sEWSEUnitOfMeasurement = BOMUnitOfMeasurement ?? string.Empty;

            if (string.IsNullOrWhiteSpace(sEWSEUnitOfMeasurement))
            {
                Err(nameof(BOMUnitOfMeasurement), BOMUnitOfMeasurement ?? "",   
                    "SEWSE unit of measurement is required.");
            }
            else
            {
                if (10 < sEWSEUnitOfMeasurement.Length)
                {
                    Err(nameof(BOMUnitOfMeasurement), BOMUnitOfMeasurement ?? "",
                        "SEWSE unit of measurement can not be greater than 10 characters.");
                }
            }

            //if (string.IsNullOrWhiteSpace(supplierGroup))
            //{
            //    Err(nameof(item.SupplierGroup), "Supplier group is required.");
            //}

            string supplierDetailComments = SupplierDetailComments ?? string.Empty;

            if (string.IsNullOrWhiteSpace(supplierDetailComments))
            {
                Err(nameof(SupplierDetailComments), "",
                    "Supplier detail comments is required.");
            }
            else
            {
                if (500 < supplierDetailComments.Length)
                {
                    Err(nameof(SupplierDetailComments), supplierDetailComments,
                        "Supplier detail comments can not be greater than 500 characters.");
                }
            }

            if (string.IsNullOrWhiteSpace(ProjectCode))
            {
                Err(nameof(ProjectCode), ProjectCode ?? "", "ProjectName Code is required.");
            }

            if (QtyPerVehicle <= 0)
            {
                Err(nameof(QtyPerVehicle), QtyPerVehicle?.ToString(CultureInfo.InvariantCulture) ?? "0.0", "QtyPerVehicle cannot be Less than 1.");
            }

            //if (VehicleTotalQuantity <= 0)
            //{
            //    Err(nameof(VehicleTotalQuantity), VehicleTotalQuantity?.ToString(CultureInfo.InvariantCulture) ?? "0.0", "Vehicle Total Quantity cannot be Less than 1.");
            //}

            //if (string.IsNullOrWhiteSpace(nPRRaisedRemarks))
            //{
            //    Err(nameof(item.NPRRaisedRemarks), "NPRRaisedRemarks is required.");
            //}

            if (string.IsNullOrWhiteSpace(ManufacturingSite))
            {
                Err(nameof(ManufacturingSite), "", "ManufacturingSite is required.");
            }

            //if (string.IsNullOrWhiteSpace(PlatformName))
            //{
            //    Err(nameof(PlatformName), "", "Platform name is required.");
            //}
            //else
            //{

            //    if (50 < PlatformName.Length)
            //    {
            //        Err(nameof(PlatformName), PlatformName,
            //            "Platform name can not be greater than 50 characters.");
            //    }
            //}

            //if (string.IsNullOrWhiteSpace(ProgramName))
            //{
            //    Err(nameof(ProgramName), "", "Program name is required.");
            //}
            //else
            //{
            //    if (50 < ProgramName.Length)
            //    {
            //        Err(nameof(ProgramName), ProgramName,
            //            "Program name can not be greater than 50 characters.");
            //    }
            //}

            if (string.IsNullOrWhiteSpace(SuggestedManufacturerGroup))
            {
                Err(nameof(SuggestedManufacturerGroup), "", "Suggested Manufacturer Can not be blank!");
            }
            else
            {
                if (50 < SuggestedManufacturerGroup.Length)
                {
                    Err(nameof(SuggestedManufacturerGroup), SuggestedManufacturerGroup,
                        "SuggestedManufacturerGroup exceeds maximum length of 50 characters");
                }
            }

            if (string.IsNullOrWhiteSpace(AssociatedParts))
            {
                Err(nameof(AssociatedParts), AssociatedParts ?? "", "Associated Parts: can not be blank");
            }
            else
            {
                string value = AssociatedParts.Trim().ToUpperInvariant();
                if (value != "YES" && value != "NO" && value != "UNKNOWN")
                {
                    Err(nameof(AssociatedParts), AssociatedParts,   
                        "AssociatedParts: Incorrect Value");
                }

                if (50 < AssociatedParts?.Length)
                {
                    Err(nameof(AssociatedParts), AssociatedParts,
                        "AssociatedParts exceeds maximum length of 50 characters");
                }
            }

            //if (nPRUploadSeqNo < 0)
            //{
            //    Err(nameof(item.NPRUploadSeqNo), "NprUploadSeqNo must be > 0.");
            //}

            //if (IsSampleDataRequired)
            //{
            //    if (SampleSiteDetails.Count <= 0)
            //    {
            //        Err(nameof(SampleSiteDetails), "", "Sample quantity must be > 0 when samples are required.");
            //    }
            //}

            if (IsSampleDataRequired)
            {
                List<RfqNprRequestSampleSiteDataUxModel> sampleSiteDetails =
                     SampleSiteDetails?.ToList() ?? new List<RfqNprRequestSampleSiteDataUxModel>();

                int sampleSiteCount = sampleSiteDetails.Count;

                if (sampleSiteCount == 0)
                {
                    Err(nameof(SampleSiteDetails), SampleSiteDetails != null ? string.Join(";", sampleSiteDetails.Select(s => s.BusinessUnitCode)) : "",    
                        "The Sample Required is True, provide Sample Site, Sample Quantity (greater than 0), Sample Recipient, and a Sample Required Date that is today or later.");
                }
                else
                {
                    foreach (RfqNprRequestSampleSiteDataUxModel site in sampleSiteDetails)
                    {
                        string businessUnitCode = site.BusinessUnitCode ?? string.Empty;
                        int sampleQty = site.SampleQty ?? 0;
                        string sendSampleContactPersonName = site.SendSampleContactPersonName ?? string.Empty;
                        DateTime? requiredDate = site.RequiredDate;

                        if (string.IsNullOrWhiteSpace(businessUnitCode))
                        {
                            Err(nameof(site.BusinessUnitCode), businessUnitCode,
                                "Sample Site can not be blank");
                        }
                        else
                        {
                            int businessUnitCodeLength = businessUnitCode.Length;

                            if (4 < businessUnitCodeLength)
                            {
                                Err(nameof(site.BusinessUnitCode), businessUnitCode,
                                    "Sample Site can not be greater than 4 characters.");
                            }
                        }

                        if (sampleQty <= 0)
                        {
                            Err(nameof(site.SampleQty), sampleQty.ToString(CultureInfo.InvariantCulture),
                                "Sample Quantity must be greater than 0");
                        }

                        if (string.IsNullOrWhiteSpace(sendSampleContactPersonName))
                        {
                            Err(nameof(site.SendSampleContactPersonName), sendSampleContactPersonName,
                                "Sample Recipient can not be blank");
                        }
                        else
                        {
                            int sendSampleContactPersonNameLength = sendSampleContactPersonName.Length;

                            if (100 < sendSampleContactPersonNameLength)
                            {
                                Err(nameof(site.SendSampleContactPersonName), sendSampleContactPersonName,
                                    "Sample Recipient can not be greater than 100 characters.");
                            }
                        }

                        // RequiredDate: required and must be today or later
                        if (requiredDate == null)
                        {
                            Err(nameof(site.RequiredDate), sendSampleContactPersonName,
                                "Sample Required Date can not be blank");
                        }
                        else
                        {
                            DateTime requiredDateValue = requiredDate.Value;
                            DateTime today = DateTime.UtcNow.Date;

                            if (requiredDate < today)
                            {
                                Err(nameof(site.RequiredDate), requiredDateValue.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                                    "Sample Required Date must be today or later");
                            }
                        }
                    }
                }
            }

            _IsValid = _ErrorCount == 0;

            return _IsValid;
        }
        #endregion
    }
}