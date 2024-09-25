using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.ETL.NPA
{
    [DataContract, NotMapped, Serializable]
    public class NpaVerificationForRfqResultModel : ExternalDataSourceModel<Guid>
    {
        private string _npaReferenceNumber;
        [DataMember, NotMapped]
        public string NPA_Ref_No
        {
            get => _npaReferenceNumber;
            set => SetProperty(ref _npaReferenceNumber, value);
        }

        private string _suggestedSupplierBuyer;
        [DataMember, NotMapped]
        public string Suggested_Supplier_Buyer
        {
            get => _suggestedSupplierBuyer;
            set => SetProperty(ref _suggestedSupplierBuyer, value);
        }

        private string _username;
        [DataMember, NotMapped]
        public string Users
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _suggestedSupplier;
        [DataMember, NotMapped]
        public string Suggested_Supplier
        {
            get => _suggestedSupplier;
            set => SetProperty(ref _suggestedSupplier, value);
        }

        private DateTime? _raisedDate;
        [DataMember, NotMapped]
        public DateTime? Raised_Date
        {
            get => _raisedDate;
            set => SetProperty(ref _raisedDate, value);
        }

        private long? _rfqId;
        [DataMember, NotMapped]
        public long? RFQ
        {
            get => _rfqId;
            set => SetProperty(ref _rfqId, value);
        }

        private DateTime? _quoteDate;
        [DataMember, NotMapped]
        public DateTime? Quote_Date
        {
            get => _quoteDate;
            set => SetProperty(ref _quoteDate, value);
        }

        private string _project;
        [DataMember, NotMapped]
        public string Project
        {
            get => _project;
            set => SetProperty(ref _project, value);
        }

        private string _rfqReferenceNumber;
        [DataMember, NotMapped]
        public string Rfq_Reference_No
        {
            get => _rfqReferenceNumber;
            set => SetProperty(ref _rfqReferenceNumber, value);
        }

        private string _sumitomoNumber;
        [DataMember, NotMapped]
        public string Sumitomo_No
        {
            get => _sumitomoNumber;
            set => SetProperty(ref _sumitomoNumber, value);
        }

        private DateTime? _rfqCutOffDate;
        [DataMember, NotMapped]
        public DateTime? Rfq_Cut_Off_Date
        {
            get => _rfqCutOffDate;
            set => SetProperty(ref _rfqCutOffDate, value);
        }

        private string _verificationStatus;
        [DataMember, NotMapped]
        public string Verification_Status
        {
            get => _verificationStatus;
            set => SetProperty(ref _verificationStatus, value);
        }

        private double? _price;
        [DataMember, NotMapped]
        public double? Price
        {
            get => _price;
            set => SetProperty(ref _price, value);
        }
    }
}
