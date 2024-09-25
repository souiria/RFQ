using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class ETLSupplierMaterialAssociationModel
    {
        private Guid _supplierMaterialAssociationGuid;
        [DataMember]
        public Guid SupplierMaterialAssociationGuid
        {
            get { return _supplierMaterialAssociationGuid; }
            set { _supplierMaterialAssociationGuid = value; }
        }

        private Guid _supplierGuid;
        [DataMember]
        public Guid SupplierGuid
        {
            get { return _supplierGuid; }
            set { _supplierGuid = value; }
        }

        private Guid _materialGuid;
        [DataMember]
        public Guid MaterialGuid
        {
            get { return _materialGuid; }
            set { _materialGuid = value; }
        }

        private string _supplierCode;
        [DataMember]
        public string SupplierCode
        {
            get { return _supplierCode; }
            set { _supplierCode = value; }
        }

        private string _materialNumber;
        [DataMember]
        public string MaterialNumber
        {
            get { return _materialNumber; }
            set { _materialNumber = value; }
        }

        private string _materialName;
        [DataMember]
        public string MaterialName
        {
            get { return _materialName; }
            set { _materialName = value; }
        }

        private string _currency;
        [DataMember]
        public string Currency
        {
            get { return _currency; }
            set { _currency = value; }
        }

        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get
            { return _isActive; }
            set
            { _isActive = value; }
        }
        private Guid _id;
        [DataMember]
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _supplierName;
        [DataMember]
        public string SupplierName
        {
            get { return _supplierName; }
            set { _supplierName = value; }
        }
    }
}
