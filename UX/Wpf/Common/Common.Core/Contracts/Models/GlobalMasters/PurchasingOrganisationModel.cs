using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class PurchasingOrganisationModel : BaseModel<Guid>
    {
        private string _purchasingOrganisationCode;
        [DataMember]
        [Required]
        [StringLength(10)]
        public string PurchasingOrganisationCode
        {
            get => _purchasingOrganisationCode;
            set => SetProperty(ref _purchasingOrganisationCode, value);
        }

        private string _purchasingOrganisationName;
        [DataMember]
        [Required]
        [StringLength(50)]
        public string PurchasingOrganisationName
        {
            get => _purchasingOrganisationName;
            set => SetProperty(ref _purchasingOrganisationName, value);
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
