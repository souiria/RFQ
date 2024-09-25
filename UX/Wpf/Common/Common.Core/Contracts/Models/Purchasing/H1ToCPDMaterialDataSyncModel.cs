using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{

    [DataContract, Serializable]
    public class H1ToCPDMaterialDataSyncModel
    {
        private Guid _id = Guid.Empty;
        [DataMember]
        public Guid Id
        {
            get => _id;
            set => _id = value;
        }
        private string _materialNumber;
        [DataMember]
        public string MaterialNumber
        {
            get => _materialNumber;
            set => _materialNumber = value;
        }

        private string _materialName;
        [DataMember]
        public string MaterialName
        {
            get => _materialName;
            set => _materialName = value;
        }

        private string _materialTypeCode;
        [DataMember]
        public string MaterialTypeCode
        {
            get => _materialTypeCode;
            set => _materialTypeCode = value;
        }

        private string _materialTypeDescription;
        [DataMember]
        public string MaterialTypeDescription
        {
            get => _materialTypeDescription;
            set => _materialTypeDescription = value;
        }

        private string _isoUnitOfMeasure;
        [DataMember]
        public string ISOUnitOfMeasure
        {
            get => _isoUnitOfMeasure;
            set => _isoUnitOfMeasure = value;
        }

        private string _sourceUnitOfMeasure;
        [DataMember]
        public string SourceUnitOfMeasure
        {
            get => _sourceUnitOfMeasure;
            set => _sourceUnitOfMeasure = value;
        }

        private decimal _cutLength;
        [DataMember]
        public decimal CutLength
        {
            get => _cutLength;
            set => _cutLength = value;
        }

        private string _commodityName;
        [DataMember]
        public string CommodityName
        {
            get => _commodityName;
            set => _commodityName = value;
        }
       
        private string _unitOfMeasure;
        [DataMember]
        public string UnitOfMeasure
        {
            get => _unitOfMeasure;
            set => _unitOfMeasure = value;
        }

        private decimal _unitWeight;
        [DataMember]
        public decimal UnitWeight
        {
            get => _unitWeight;
            set => _unitWeight = value;
        }

        private CrudOperationType _crudOperationType;
        [DataMember]
        public CrudOperationType CrudOperationType
        {
            get => _crudOperationType;
            set => _crudOperationType = value;
        }
        private string _error;
        [DataMember]
        public string Error
        {
            get => _error;
            set => _error = value;
        }
    }

    [DataContract, Serializable]
    public class H1ToCPDMaterialModel
    {
        private Guid _materialGuid = Guid.Empty;
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

        private string _materialName;
        [DataMember]
        public string MaterialName
        {
            get => _materialName;
            set => _materialName = value;
        }

       
        private Guid _unitOfMeasureGuid;
        [DataMember]
        public Guid UnitOfMeasureGuid
        {
            get => _unitOfMeasureGuid;
            set => _unitOfMeasureGuid = value;
        }

        private decimal _unitWeight;
        [DataMember]
        public decimal UnitWeight
        {
            get => _unitWeight;
            set => _unitWeight = value;
        }

        private CrudOperationType _crudOperationType;
        [DataMember]
        public CrudOperationType CrudOperationType
        {
            get => _crudOperationType;
            set => _crudOperationType = value;
        }
      
    }
}
