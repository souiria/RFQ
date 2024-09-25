using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class SupplierSelectionModel : BaseModel<Guid>
    {
        private Guid _supplierMaterialAssociationGuid;
        [DataMember]
        [Required]
        public Guid SupplierMaterialAssociationGuid
        {
            get => _supplierMaterialAssociationGuid;
            set => SetProperty(ref _supplierMaterialAssociationGuid, value);
        }
        private Guid _businessUnitGuid;
        [DataMember]
        [Required]
        public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => SetProperty(ref _businessUnitGuid, value);
        }
        private int _transitLeadTime;
        [DataMember]
        [Required]
        public int TransitLeadTime
        {
            get => _transitLeadTime;
            set => SetProperty(ref _transitLeadTime, value);
        }

        private DateTime _effectiveDate;
        [DataMember]
        public DateTime EffectiveDate
        {
            get => _effectiveDate;
            set => SetProperty(ref _effectiveDate, value);
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
