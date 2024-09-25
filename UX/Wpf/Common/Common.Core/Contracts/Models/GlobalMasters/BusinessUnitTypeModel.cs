using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class BusinessUnitTypeModel : BaseModel<Guid>
    {
        private string _businessUnitTypeName;
        [DataMember]
        [Required]
        [StringLength(50)]
        public string BusinessUnitTypeName
        {
            get => _businessUnitTypeName;
            set => SetProperty(ref _businessUnitTypeName, value);
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
