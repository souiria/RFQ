using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class PaymentTermsModel : BaseModel<Guid>
    {
        private bool? _isRowChecked = false;
        [NotMapped, DataMember]
        public bool? IsRowChecked
        {
            get => _isRowChecked;
            set => SetProperty(ref _isRowChecked, value);
        }

        private string _paymentTerms;
        [DataMember]
        [Required]
        [StringLength(50)]
        public string PaymentTerms
        {
            get => _paymentTerms;
            set => SetProperty(ref _paymentTerms, value);
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
