using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class FirstReceiptDateSearchModel
    {
        private Guid _businessUnit;
        [DataMember]
        public Guid BusinessUnitGuid
        {
            get => _businessUnit;
            set => _businessUnit = value;
        }
        private string _businessUnitCode;
        [DataMember]
        public string BusinessUnitCode
        {
            get => _businessUnitCode;
            set => _businessUnitCode = value;
        }
        private Guid _supplierGuid;
        [DataMember]
        public Guid SupplierGuid
        {
            get => _supplierGuid;
            set => _supplierGuid = value;
        }
        private string _supplierCode;
        [DataMember]
        public string SupplierCode
        {
            get => _supplierCode;
            set => _supplierCode= value;
        }
        private Guid _materialGuid;
        [DataMember]
        public Guid MaterialGuid
        {
            get => _materialGuid;
            set => _materialGuid = value;
        }
        private string _materialNumber;
        [DataMember]
        public string MaterialNumber
        {
            get => _materialNumber;
            set => _materialNumber =value;
        }
        private DateTime? _dateRangeFrom;
        [DataMember]
        public DateTime? DateRangeFrom
        {
            get => _dateRangeFrom;
            set => _dateRangeFrom = value;
        }
        private DateTime? _dateRangeTo;
        [DataMember]
        public DateTime? DateRangeTo
        {
            get => _dateRangeTo;
            set => _dateRangeTo = value;
        }
    }
}
