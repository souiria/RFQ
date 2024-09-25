using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class UnitOfMeasureModel : BaseModel<Guid>
    {
        private string _code;
        [DataMember]
        [Required]
        [StringLength(2)]
        public string Code
        {
            get => _code;
            set => SetProperty(ref _code, value);
        }

        private string _unitOfMeasurementDescription;
        [DataMember]
        [Required]
        [StringLength(255)]
        public string UnitOfMeasureDescription
        {
            get => _unitOfMeasurementDescription;
            set => SetProperty(ref _unitOfMeasurementDescription, value);
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
