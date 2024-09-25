using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{

    [DataContract, Serializable]
    public  class MaterialOriginSearchModel
    {
        
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
        private bool _isSortByMaterialNo=true;
        [DataMember]
        public bool IsSortByMaterialNo {
            get=> _isSortByMaterialNo;
            set=>_isSortByMaterialNo=value;
        }
    }
}
