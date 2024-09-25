using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class CommodityModel : BaseModel<Guid>
    {
        private string _commodityName;
        [DataMember]
        [Required]
        [StringLength(30)]
        public string CommodityName
        {
            get => _commodityName;
            set => SetProperty(ref _commodityName, value);
        }

        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }
    }
}
