using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class PurchasingCommodityModel : BaseModel<Guid>
    {
        private Guid _commodityGuid;
        [DataMember]
        [Required]
        public Guid CommodityGuid
        {
            get => _commodityGuid;
            set => SetProperty(ref _commodityGuid, value);
        }

        private string _commodityGroupCode;
        [DataMember]
        [Required]
        [StringLength(4)]
        public string CommodityGroupCode
        {
            get => _commodityGroupCode;
            set => SetProperty(ref _commodityGroupCode, value);
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
