using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    /// <summary>
    /// Data Contract to map Customer Group with Customer
    /// </summary>
    [DataContract, Serializable]
    public class PurchasingCustomerGroupModel : BaseModel<Guid>
    {
        private Guid _purchasingCustomerGuid;
        [DataMember]
        [Required]
        public Guid PurchasingCustomerGuid
        {
            get => _purchasingCustomerGuid;
            set => SetProperty(ref _purchasingCustomerGuid, value);
        }

        private string _customerGroupCode;
        [DataMember]
        [Required]
        [StringLength(50)]
        public string CustomerGroupCode
        {
            get => _customerGroupCode;
            set => SetProperty(ref _customerGroupCode, value);
        }
    }
}
