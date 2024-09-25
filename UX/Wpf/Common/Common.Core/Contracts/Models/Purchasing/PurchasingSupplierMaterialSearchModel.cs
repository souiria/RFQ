using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class PurchasingSupplierMaterialSearchModel
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
        private Guid _materialFromGuid;
        [DataMember]
        public Guid MaterialFromGuid
        {
            get => _materialFromGuid;
            set => _materialFromGuid = value;
        }
        private string _materialNumberFrom = string.Empty;
        [DataMember]
        public string MaterialNumberFrom
        {
            get => _materialNumberFrom;
            set => _materialNumberFrom = value;
        }
        private Guid _materialToGuid;
        [DataMember]
        public Guid MaterialToGuid
        {
            get => _materialToGuid;
            set => _materialToGuid = value;
        }
        private string _materialNumberTo = string.Empty;
        [DataMember]
        public string MaterialNumberTo
        {
            get => _materialNumberTo;
            set => _materialNumberTo = value;
        }
        private byte _materialListOption = 1; /*1: All; 2- In-complete; 3: No Pricing */
        [DataMember]
        public byte MaterialListOption
        {
            get => _materialListOption;
            set => _materialListOption = value;
        }
    }

    [DataContract, Serializable]
    public class PurchasingSupplierMaterialPOPricingSearchModel
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
        private Guid _materialFromGuid;
        [DataMember]
        public Guid MaterialFromGuid
        {
            get => _materialFromGuid;
            set => _materialFromGuid = value;
        }
        private string _materialNumberFrom = string.Empty;
        [DataMember]
        public string MaterialNumberFrom
        {
            get => _materialNumberFrom;
            set => _materialNumberFrom = value;
        }
        private Guid _materialToGuid;
        [DataMember]
        public Guid MaterialToGuid
        {
            get => _materialToGuid;
            set => _materialToGuid = value;
        }
        private string _materialNumberTo = string.Empty;
        [DataMember]
        public string MaterialNumberTo
        {
            get => _materialNumberTo;
            set => _materialNumberTo = value;
        }
        private string _pOPriceTypeCode = string.Empty;
        [DataMember]
        public string POPriceTypeCode
        {
            get => _pOPriceTypeCode;
            set => _pOPriceTypeCode = value;
        }
        private Guid _pOPriceTypeGuid;
        [DataMember]
        public Guid POPriceTypeGuid
        {
            get => _pOPriceTypeGuid;
            set => _pOPriceTypeGuid = value;
        }

        private DateTime? _effectiveDateFrom;
        [DataMember]
        public DateTime? EffectiveDateFrom
        {
            get => _effectiveDateFrom;
            set => _effectiveDateFrom = value;
        }
        private DateTime? _effectiveDateTo;
        [DataMember]
        public DateTime? EffectiveDateTo
        {
            get => _effectiveDateTo;
            set => _effectiveDateTo = value;
        }
        private byte _approvedStatus = 1; /*1: Both; 2- Approved; 3: Not Approved */
        [DataMember]
        public byte ApprovedStatus
        {
            get => _approvedStatus;
            set => _approvedStatus = value;
        }
    }
}