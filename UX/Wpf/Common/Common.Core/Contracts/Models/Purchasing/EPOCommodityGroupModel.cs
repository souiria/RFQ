using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class EPOCommodityGroupModel : BaseModel<Guid>
    {
        private string _epoCommodityGroupCode;
        [DataMember]
        [Required]
        [StringLength(15)]
        public string EPOCommodityGroupCode
        {
            get => _epoCommodityGroupCode;
            set => SetProperty(ref _epoCommodityGroupCode, value);
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
