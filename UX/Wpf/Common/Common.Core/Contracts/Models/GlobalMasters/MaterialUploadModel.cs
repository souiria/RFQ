using System;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class MaterialUploadModel : BaseModel<Guid>
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

        private Guid _sourceApplicationGuid = Guid.Empty;
        [DataMember]
        //Navigation Property
        public Guid SourceApplicationGuid
        {
            get => _sourceApplicationGuid;
            set => SetProperty(ref _sourceApplicationGuid, value);
        }

        private Guid _unitOfMeasureGuid;
        [DataMember]
        //Navigation Property
        public Guid UnitOfMeasureGuid
        {
            get => _unitOfMeasureGuid;
            set => SetProperty(ref _unitOfMeasureGuid, value);
        }

        private string _preProductionNumber;
        [DataMember]
        public string PreProductionNumber
        {
            get => _preProductionNumber;
            set => SetProperty(ref _preProductionNumber, value);
        }

        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }

        private string _unitOfMeasure;
        [DataMember]
        public string UnitOfMeasure
        {
            get { return _unitOfMeasure; }
            set { SetProperty(ref _unitOfMeasure, value); }
        }
        #region Association

        private Guid _materialAssociationGuid;
        [DataMember]
        public Guid MaterialAssociationGuid
        {
            get { return _materialAssociationGuid; }
            set { SetProperty(ref _materialAssociationGuid, value); }
        }

        private string _materialType;
        [DataMember]
        public string MaterialType
        {
            get { return _materialType; }
            set { SetProperty(ref _materialType, value); }
        }
        private Guid _materialTypeGuid;
        [DataMember]
        public Guid MaterialTypeGuid
        {
            get { return _materialTypeGuid; }
            set { SetProperty(ref _materialTypeGuid, value); }
        }

        private string _commodityName;
        [DataMember]
        public string CommodityName
        {
            get { return _commodityName; ; }
            set { SetProperty(ref _commodityName, value); }
        }

        private Guid _commodityGuid;
        [DataMember]
        public Guid CommodityGuid
        {
            get { return _commodityGuid; }
            set { SetProperty(ref _commodityGuid, value); }
        }

        private decimal _unitWeight;
        [DataMember]
        public decimal UnitWeight
        {
            get { return _unitWeight; }
            set { SetProperty(ref _unitWeight, value); }
        }

        private decimal _cutLength;
        [DataMember]
        public decimal CutLength
        {
            get { return _cutLength; }
            set { SetProperty(ref _cutLength, value); }
        }
        #endregion
    }
}
