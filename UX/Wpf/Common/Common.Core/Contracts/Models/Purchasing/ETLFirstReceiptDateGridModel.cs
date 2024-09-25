using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class ETLFirstReceiptDateGridModel :BaseModel<Guid>
    {
        private string _materialNumber;
        [DataMember]
        public string MaterialNumber
        {
            get => _materialNumber;
            set => SetProperty(ref _materialNumber, value);
        }

        private string _materialName;
        [DataMember]
        public string MaterialName
        {
            get => _materialName;
            set => SetProperty(ref _materialName, value);
        }

        private string _supplierCode;
        [DataMember]
        public string SupplierCode
        {
            get => _supplierCode;
            set => SetProperty(ref _supplierCode, value);
        }

        private string _supplierName;
        [DataMember]
        public string SupplierName
        {
            get => _supplierName;
            set => SetProperty(ref _supplierName, value);
        }

        private string _businessUnitCode;
        [DataMember]
        public string BusinessUnitCode
        {
            get => _businessUnitCode;
            set => SetProperty(ref _businessUnitCode, value);
        }
        private string _businessUnitName;
        [DataMember]
        public string BusinessUnitName
        {
            get => _businessUnitName;
            set => SetProperty(ref _businessUnitName, value);
        }
        private string _code;
        [DataMember]
        public string Code
        {
            get => _code;
            set => SetProperty(ref _code, value);
        }
        private string _unitOfMeasurementDescription;
        [DataMember]
        public string UnitOfMeasureDescription
        {
            get => _unitOfMeasurementDescription;
            set => SetProperty(ref _unitOfMeasurementDescription, value);
        }
       
        private string _supplierMaterialNumber;
        [DataMember]
         public string SupplierMaterialNumber
        {
            get => _supplierMaterialNumber;
            set => SetProperty(ref _supplierMaterialNumber, value);
        }

        private string _supplierMaterialName;
        [DataMember]
        public string SupplierMaterialName
        {
            get => _supplierMaterialName;
            set => SetProperty(ref _supplierMaterialName, value);
        }
        private Guid _supplierGuid;
        [DataMember]     
        public Guid SupplierGuid
        {
            get => _supplierGuid;
            set => SetProperty(ref _supplierGuid, value);
        }
        private Guid _materialGuid;
        [DataMember]     
        public Guid MaterialGuid
        {
            get => _materialGuid;
            set => SetProperty(ref _materialGuid, value);
        }

        private Guid _businessUnitGuid;
        [DataMember]
         public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => SetProperty(ref _businessUnitGuid, value);
        }

        private Guid _purchasingSupplierMaterialHierarchyGuid;
        [DataMember]
        public Guid PurchasingSupplierMaterialHierarchyGuid
        {
            get => _purchasingSupplierMaterialHierarchyGuid;
            set => SetProperty(ref _purchasingSupplierMaterialHierarchyGuid, value);
        }
        private string _poNumber;
        [DataMember]
    
        public string PONumber
        {
            get => _poNumber;
            set => SetProperty(ref _poNumber, value);
        }

        private decimal _poPrice;
        [DataMember]
     
        public decimal POPrice
        {
            get => _poPrice;
            set => SetProperty(ref _poPrice, value);
        }

        private int _receivedQuantity;
        [DataMember]
        public int ReceivedQuantity
        {
            get => _receivedQuantity;
            set => SetProperty(ref _receivedQuantity, value);
        }

        private Guid _unitOfMeasureGuid;
        [DataMember]
        public Guid UnitOfMeasureGuid
        {
            get => _unitOfMeasureGuid;
            set => SetProperty(ref _unitOfMeasureGuid, value);
        }

        private DateTime _receiptDate;
        [DataMember]
        public DateTime ReceiptDate
        {
            get => _receiptDate;
            set => SetProperty(ref _receiptDate, value);
        }

        private string _transferFlag;
        [DataMember]     
        public string TransferFlag
        {
            get => _transferFlag;
            set => SetProperty(ref _transferFlag, value);
        }
    }
}
