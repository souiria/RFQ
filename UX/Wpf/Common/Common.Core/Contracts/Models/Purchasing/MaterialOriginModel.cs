using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class MaterialOriginModel : BaseModel<Guid>
    {
        private Guid _supplierMaterialAssociationGuid;
        [DataMember]
        [Required]
        public Guid SupplierMaterialAssociationGuid
        {
            get => _supplierMaterialAssociationGuid;
            set => SetProperty(ref _supplierMaterialAssociationGuid, value);
        }

        
        private Guid _tariffCodeAssociationGuid;
        [DataMember]
        public Guid TariffCodeAssociationGuid
        {
            get => _tariffCodeAssociationGuid;
            set => SetProperty(ref _tariffCodeAssociationGuid, value);
        }
        private string _origin;
        [DataMember]
        [StringLength(15)]
        public string Origin
        {
            get => _origin;
            set => SetProperty(ref _origin, value);
        }

        private DateTime _expiryDate;
        [DataMember] 
        public DateTime ExpiryDate
        {
            get => _expiryDate;
            set => SetProperty(ref _expiryDate, value);
        }
    }
}
