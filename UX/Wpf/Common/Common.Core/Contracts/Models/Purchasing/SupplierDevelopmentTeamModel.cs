using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class SupplierDevelopmentTeamModel : BaseModel<Guid>
    {
        private Guid _sDEUserCode;
        [DataMember]
        [Required]
        public Guid SDEUserCode
        {
            get => _sDEUserCode;
            set => SetProperty(ref _sDEUserCode, value);
        }

        private string _sDEUserID;
        [DataMember]
        [Required]
        [StringLength(50)]
        public string SDEUserID
        {
            get => _sDEUserID;
            set => SetProperty(ref _sDEUserID, value);
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
