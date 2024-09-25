using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    /// <inheritdoc />
    /// <summary>
    /// Represents a row of Currency data.
    /// </summary>
    [DataContract, Serializable]
    public class POPriceEffectiveDateTypeModel : BaseModel<Guid>
    {
        private string poPriceEffectiveDateTypeDescription;
        [DataMember]
        [Required]
        [StringLength(50)]
        public string POPriceEffectiveDateTypeDescription
        {
            get => poPriceEffectiveDateTypeDescription;
            set => SetProperty(ref poPriceEffectiveDateTypeDescription, value);
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