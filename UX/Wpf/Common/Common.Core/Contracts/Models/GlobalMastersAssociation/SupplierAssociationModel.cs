using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMastersAssociation
{
    [DataContract, Serializable]
   public class SupplierAssociationModel  :BaseModel<Guid>
    {

        private Guid _supplierGuid;
        [DataMember]
        [Required]
        public Guid SupplierGuid
        {
            get => _supplierGuid;
            set => SetProperty(ref _supplierGuid, value);
        }

        private Guid _supplierTypeGuid;
        [DataMember]
        [Required]
        public Guid SupplierTypeGuid
        {
            get => _supplierTypeGuid;
            set => SetProperty(ref _supplierTypeGuid, value);
        }

        private Guid _supplierGroupGuid;
        [DataMember]
        [Required]
        public Guid SupplierGroupGuid
        {
            get => _supplierGroupGuid;
            set => SetProperty(ref _supplierGroupGuid, value);
        }

        //Ajay: 13-Feb-2018
        //Addition of association
        private Guid _supplierIncoTermsGuid;
        [DataMember]
        [Required]
        public Guid SupplierIncoTermsGuid
        {
            get => _supplierIncoTermsGuid;
            set => SetProperty(ref _supplierIncoTermsGuid, value);
        }

        private Guid _supplierCurrencyGuid;
        [DataMember]
        [Required]
        public Guid SupplierCurrencyGuid
        {
            get => _supplierCurrencyGuid;
            set => SetProperty(ref _supplierCurrencyGuid, value);
        }

        private Guid _supplierBuyerGuid;
        [DataMember]
        [Required]
        public Guid SupplierBuyerGuid
        {
            get => _supplierBuyerGuid;
            set => SetProperty(ref _supplierBuyerGuid, value);
        }

        private Guid _supplierTransporterCurrencyGuid;
        [DataMember]
        [Required]
        public Guid SupplierTransporterCurrencyGuid
        {
            get => _supplierTransporterCurrencyGuid;
            set => SetProperty(ref _supplierTransporterCurrencyGuid, value);
        }

        //Pawan: 15-Feb-2018
        //Addition of association for SDE
        private Guid _supplierDevelopmentTeamGuid;
        [DataMember]
        [Required]
        public Guid SupplierDevelopmentTeamGuid
        {
            get => _supplierDevelopmentTeamGuid;
            set => SetProperty(ref _supplierDevelopmentTeamGuid, value);
        }
    }
}
