using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Common.Core.Infrastructure.Attributes;

namespace Common.Core.Contracts.Models.Purchasing
{
    public class PurchasingMaterialModel : BaseModel<Guid>
    {
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

        private Guid _unitOfMeasurementGuid;
        [DataMember]
        [Required]
        public Guid UnitOfMeasurementGuid
        {
            get => _unitOfMeasurementGuid;
            set => SetProperty(ref _unitOfMeasurementGuid, value);
        }

        private Guid _commodityGuid;
        [DataMember]
        [Required]
        public Guid CommodityGuid
        {
            get => _commodityGuid;
            set => SetProperty(ref _commodityGuid, value);
        }

        private string _npaComments;
        [DataMember]
        [StringLength(30)]
        public string NPAComments
        {
            get => _npaComments;
            set => SetProperty(ref _npaComments, value);
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

        private bool _finishedGoodsFlag;
        [DataMember]
        public bool FinishedGoodsFlag
        {
            get => _finishedGoodsFlag;
            set => SetProperty(ref _finishedGoodsFlag, value);
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
