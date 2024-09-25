using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public  class H1ToCPDSupplierMaterialPOPricingModel
    {
        private int _recordEntryID;
        [DataMember]
        public int RecordEntryID
        {
            get => _recordEntryID;
            set =>  _recordEntryID= value;
        }    

        private Guid _supplierMaterialGuid;
        [DataMember]
        public Guid SupplierMaterialGuid
        {
            get => _supplierMaterialGuid;
            set =>  _supplierMaterialGuid= value;
        }

        private string _supplierCode;
        [DataMember]
        public string SupplierCode
        {
            get => _supplierCode;
            set => _supplierCode = value;
        }
        private Guid _supplierGuid;
        [DataMember]
        public Guid SupplierGuid
        {
            get => _supplierGuid;
            set => _supplierGuid = value;
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
            set => _materialNumber = value;
        }

        private string _poPriceTypeCode;
        [DataMember]
        public string POPriceTypeCode
        {
            get => _poPriceTypeCode;
            set => _poPriceTypeCode = value;
        }

        private decimal _poPrice;
        [DataMember]
        public decimal POPrice
        {
            get => _poPrice;
            set =>  _poPrice= value;
        }

        private decimal _metalWeight;
        [DataMember]
        public decimal MetalWeight
        {
            get => _metalWeight;
            set =>  _metalWeight= value;
        }


        private decimal _metalRate;
        [DataMember]
        public decimal MetalRate
        {
            get => _metalRate;
            set =>  _metalRate= value;
        }

        private decimal _poPriceExcludingMetal;
        [DataMember]
        public decimal POPriceExcludingMetal
        {
            get => _poPriceExcludingMetal;
            set =>  _poPriceExcludingMetal= value;
        }

        private DateTime _effectiveFromDate;
        [DataMember]
        public DateTime EffectiveFromDate
        {
            get => _effectiveFromDate;
            set =>  _effectiveFromDate= value;
        }

        private Guid _priceTypeGuid;
        [DataMember]
          public Guid PriceTypeGuid
        {
            get => _priceTypeGuid;
            set =>  _priceTypeGuid= value;
        }

        private string _priceChangeNotification;
        [DataMember]
        public string PriceChangeNotification
        {
            get => _priceChangeNotification;
            set =>  _priceChangeNotification= value;
        }
        private string _approved;
        [DataMember]
        public string Approved
        {
            get => _approved;
            set =>  _approved= value;
        }


        private DateTime _approvedDate;
        [DataMember]
        public DateTime ApprovedDate 
        {
            get => _approvedDate;
            set =>  _approvedDate= value;
        }

        private CrudOperationType _crudOperationType;
        [DataMember]
        public CrudOperationType CrudOperationType
        {
            get => _crudOperationType;
            set => _crudOperationType = value;
        }
    }

    [DataContract, Serializable]
    public class H1ToCPDSupplierMaterialPOPricingDataSyncModel : H1ToCPDSupplierMaterialPOPricingModel
    {
       
        private string _error;
        [DataMember]
        public string Error
        {
            get => _error;
            set => _error = value;
        }
        private Guid _id;
        [DataMember]
        public Guid Id
        {
            get => _id;
            set => _id = value;
        }
    }
}
