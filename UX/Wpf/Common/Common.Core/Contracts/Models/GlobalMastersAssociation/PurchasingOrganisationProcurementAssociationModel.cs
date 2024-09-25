using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMastersAssociation 
{
    [DataContract, Serializable]
    public class PurchasingOrganisationProcurementAssociationModel : BaseModel<Guid>
    {
        private Guid _purchasingOrganisationGuid;
        [DataMember]
        [Required]
        public Guid PurchasingOrganisationGuid
        {
            get => _purchasingOrganisationGuid;
            set => SetProperty(ref _purchasingOrganisationGuid, value);
        }

        private Guid _procurementUnitGuid;
        [DataMember]
        [Required]
        public Guid ProcurementUnitGuid
        {
            get => _procurementUnitGuid;
            set => SetProperty(ref _procurementUnitGuid, value);
        }

        private string _npaPrefix;
        [DataMember]
        [Required]
        [StringLength(10)]
        public string NPAPrefix
        {
            get { return _npaPrefix; }
            set { _npaPrefix = value; }
        }
    }
}
