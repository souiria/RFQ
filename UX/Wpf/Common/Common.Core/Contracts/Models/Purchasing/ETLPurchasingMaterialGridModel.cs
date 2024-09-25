using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Common.Core.Infrastructure.Attributes;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class ETLPurchasingMaterialGridModel : BaseModel<Guid>
    {
        private string _materialNo;
        [DataMember]
        public string MaterialNo
        {
            get { return _materialNo; }
            set { SetProperty(ref _materialNo, value); }
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
        [Required]
        public Guid CommodityGuid
        {
            get => _commodityGuid;
            set => SetProperty(ref _commodityGuid, value);
        }

        private string _materialName;
        [DataMember]
        public string MaterialName
        {
            get { return _materialName; }
            set { SetProperty(ref _materialName, value); }
        }

        private Guid _materialGuid;
        [DataMember]
        [Required]
        public Guid MaterialGuid
        {
            get => _materialGuid;
            set => SetProperty(ref _materialGuid, value);
        }
        private string _preProductionNumber;
        [DataMember]
        public string PreProductionNumber
        {
            get { return _preProductionNumber; ; }
            set { SetProperty(ref _preProductionNumber, value); }
        }
        private string _materialType;
        [DataMember]
        public string MaterialType
        {
            get { return _materialType; }
            set { SetProperty(ref _materialType, value); }
        }
        private string _commodityName;
        [DataMember]
        public string CommodityName
        {
            get { return _commodityName; ; }
            set { SetProperty(ref _commodityName, value); }
        }


        private decimal _cutLength;
        [DataMember]
        [Required]
        [DecimalPrecision(5, 3)]
        public decimal CutLength
        {
            get => _cutLength;
            set => SetProperty(ref _cutLength, value);
        }

        private string _bomUnit;
        [DataMember]
        public string BOMUnit
        {
            get { return _bomUnit; ; }
            set { SetProperty(ref _bomUnit, value); }
        }

        private bool _isActive = true;
        [DataMember]
        public new bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }
    }
}
