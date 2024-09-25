using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    /// <summary>
    /// To manage Customer details for Purchasing
    /// </summary>
    public class PurchasingCustomerModel : BaseModel<Guid>
    {
        private string _purchasingCustomerCode;
        [DataMember]
        [StringLength(50)]
        [Required]
        public string PurchasingCustomerCode
        {
            get => _purchasingCustomerCode;
            set => SetProperty(ref _purchasingCustomerCode, value);
        }

        private string _purchasingCustomerName;
        [DataMember]
        [StringLength(50)]
        [Required]
        public string PurchasingCustomerName
        {
            get => _purchasingCustomerName;
            set => SetProperty(ref _purchasingCustomerName, value);
        }

    }
}
