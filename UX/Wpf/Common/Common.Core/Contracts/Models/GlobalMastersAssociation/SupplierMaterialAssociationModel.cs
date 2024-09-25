using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMastersAssociation
{
    public class SupplierMaterialAssociationModel:BaseModel<Guid>
    {
        private Guid _supplierGuid;
        [DataMember]
        [Required]
        public Guid SupplierGuid
        {
            get => _supplierGuid;
            set => SetProperty(ref _supplierGuid, value);
        }

        private Guid _materialGuid;
        [DataMember]
        [Required]
        public Guid MaterialGuid 
        {
            get => _materialGuid;
            set => SetProperty(ref _materialGuid, value);
        }

        private bool _isFCExists = false;
        [DataMember]
        public bool IsFCExists
        {
            get => _isFCExists;
            set => SetProperty(ref _isFCExists, value);
        }
    }
}
