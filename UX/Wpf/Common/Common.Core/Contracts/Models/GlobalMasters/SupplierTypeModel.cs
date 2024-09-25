using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class SupplierTypeModel : BaseModel<Guid>
    {

        private string _supplierTypeDescription;
        [DataMember]
        [Required]
        [StringLength(50)]
        public string SupplierTypeDescription
        {
            get => _supplierTypeDescription;
            set => SetProperty(ref _supplierTypeDescription, value);
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
