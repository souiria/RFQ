using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    /// <summary>
    /// To manage Vehicle details for Purchasing
    /// </summary>
    public class PurchasingVehicleModel : BaseModel<Guid>
    {
        private string _purchasingVehicleCode;
        [DataMember]
        [StringLength(50)]
        [Required]
        public string PurchasingVehicleCode
        {
            get => _purchasingVehicleCode;
            set => SetProperty(ref _purchasingVehicleCode, value);
        }

        private string _purchasingVehicleName;
        [DataMember]
        [StringLength(50)]
        [Required]
        public string PurchasingVehicleName
        {
            get => _purchasingVehicleName;
            set => SetProperty(ref _purchasingVehicleName, value);
        }

    }
}
