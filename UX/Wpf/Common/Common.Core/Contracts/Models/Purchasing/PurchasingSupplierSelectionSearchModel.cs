using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class PurchasingSupplierSelectionSearchModel
    {
        private Guid _supplierGuid;
        [DataMember]
        public Guid SupplierGuid
        {
            get => _supplierGuid;
            set => _supplierGuid = value;
        }
        private string _supplierCode = string.Empty;
        [DataMember]
        public string SupplierCode
        {
            get => _supplierCode;
            set => _supplierCode = value;
        }
        private Guid _materialGuid;
        [DataMember]
        public Guid MaterialGuid
        {
            get => _materialGuid;
            set => _materialGuid = value;
        }
        private string _materialNumber = string.Empty;
        [DataMember]
        public string MaterialNumber
        {
            get => _materialNumber;
            set => _materialNumber = value;
        }
        private string _businessUnit = string.Empty;
        [DataMember]
        public string BusinessUnit
        {
            get => _businessUnit;
            set => _businessUnit = value;
        }
        private Guid _businessUnitGuid;
        [DataMember]
        public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => _businessUnitGuid = value;
        }
        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }

    }
}
