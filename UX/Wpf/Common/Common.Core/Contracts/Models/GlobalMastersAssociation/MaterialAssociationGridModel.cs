using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Common.Core.Infrastructure.Attributes;

namespace Common.Core.Contracts.Models.GlobalMastersAssociation
{
    [DataContract]
    public class MaterialAssociationGridModel : BaseModel<Guid>
    {
        [DataMember]
        private string _materialNumber;
        public string MaterialNumber
        {
            get => _materialNumber;
            set => _materialNumber = value;
        }

        [DataMember]
        private string _materialName;
        public string MaterialName
        {
            get => _materialName;
            set => _materialName = value;
        }

        [DataMember]
        private string _materialTypeCode;
        public string MaterialTypeCode
        {
            get => _materialTypeCode;
            set => _materialTypeCode = value;
        }

        [DataMember]
        private string _materialTypeName;
        public string MaterialTypeName
        {
            get => _materialTypeName;
            set => _materialTypeName = value;
        }

        [DataMember]
        private string _commodityName;
        public string CommodityName
        {
            get => _commodityName;
            set => _commodityName = value;
        }
        private Guid _materialGuid;
        [DataMember]
        [Required]
        public Guid MaterialGuid
        {
            get => _materialGuid;
            set => SetProperty(ref _materialGuid, value);
        }
        
        private Guid _materialTypeGuid;
        [DataMember]
        [Required]
        public Guid MaterialTypeGuid
        {
            get => _materialTypeGuid;
            set => SetProperty(ref _materialTypeGuid, value);
        }
      
        private Guid _commodityGuid;
        [DataMember]
        public Guid CommodityGuid
        {
            get => _commodityGuid;
            set => SetProperty(ref _commodityGuid, value);
        }
      
        private decimal _cutLength;
        [DataMember]
        [DecimalPrecision(8, 3)]
        public decimal CutLength
        {
            get => _cutLength;
            set => SetProperty(ref _cutLength, value);
        }


    }

    [DataContract, Serializable]
    public class MaterialAssociationListModel
    {
        private Guid _materialGuid;
        [DataMember]
        public Guid MaterialGuid
        {
            get { return _materialGuid; }
            set { _materialGuid = value; }
        }
        private bool _isMaterialAssociationExists = false;
        [DataMember]
        public bool IsMaterialAssociationExists
        {
            get { return _isMaterialAssociationExists; }
            set { _isMaterialAssociationExists = value; }
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
        private bool _isActive;
        [DataMember]
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

    }

}
