using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract]
  public  class ETLPurchasingSupplierMaterialComboModel
    {
        private Guid _materialGuid;
        [DataMember]
        public Guid MaterialGuid
        {
            get=> _materialGuid; 
            set => _materialGuid = value; 
        }

        private Guid _supplierMaterialGuid;
        [DataMember]
        public Guid SupplierMaterialGuid
        {
            get => _supplierMaterialGuid; 
            set => _supplierMaterialGuid = value; 
        }
        [DataMember]
        private Guid _supplierGuid;
        public Guid SupplierGuid
        {
            get => _supplierGuid; 
            set =>_supplierGuid = value; 
        }

        private string _supplierCode;
        [DataMember]
        public string SupplierCode
        {
            get => _supplierCode; 
            set =>_supplierCode = value; 
        }

        private string _materialNumber;
        [DataMember]
        public string MaterialNumber
        {
            get => _materialNumber; 
            set =>_materialNumber = value; 
        }

        private string _materialName;
        [DataMember]
        public string MaterialName
        {
            get =>_materialName; 
            set => _materialName = value; 
        }

        private int _orderLeadTime;
        [DataMember]
        public int OrderLeadTime
        {
            get => _orderLeadTime; 
            set => _orderLeadTime = value; 
        }

        private Guid _id;
        [DataMember]
        public Guid Id
        {
            get => _id; 
            set =>_id = value;
        }

        private bool _isActive;
        [DataMember]
        public bool IsActive
        {
            get => _isActive; 
            set => _isActive = value; 
        }
    }
}
