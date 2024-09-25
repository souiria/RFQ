using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing 
{[DataContract, Serializable]
   public class H1ToCPDSupplierAssociationModel
    {
        private Guid _supplierAssociationGuid;
        [DataMember]
        public Guid SupplierAssociationGuid
        {
            get => _supplierAssociationGuid;
            set => _supplierAssociationGuid = value;
        }
        private Guid _supplierGuid;
        [DataMember] 
        public Guid SupplierGuid
        {
            get => _supplierGuid;
            set =>  _supplierGuid = value;
        }

        private Guid _supplierTypeGuid;
        [DataMember] 
        public Guid SupplierTypeGuid
        {
            get => _supplierTypeGuid;
            set => _supplierTypeGuid = value;
        }

        private Guid _supplierGroupGuid;
        [DataMember] 
        public Guid SupplierGroupGuid
        {
            get => _supplierGroupGuid;
            set => _supplierGroupGuid = value;
        }

         private Guid _supplierIncoTermsGuid;
        [DataMember]
        
        public Guid SupplierIncoTermsGuid
        {
            get => _supplierIncoTermsGuid;
            set =>  _supplierIncoTermsGuid= value;
        }

        private Guid _supplierCurrencyGuid;
        [DataMember] 
        public Guid SupplierCurrencyGuid
        {
            get => _supplierCurrencyGuid;
            set =>   _supplierCurrencyGuid= value;
        }

        private Guid _supplierBuyerGuid;
        [DataMember] 
        public Guid SupplierBuyerGuid
        {
            get => _supplierBuyerGuid;
            set =>   _supplierBuyerGuid= value;
        }

        private Guid _supplierTransporterCurrencyGuid;
        [DataMember] 
        public Guid SupplierTransporterCurrencyGuid
        {
            get => _supplierTransporterCurrencyGuid;
            set =>  _supplierTransporterCurrencyGuid= value;
        }

        private Guid _supplierDevelopmentTeamGuid;
        [DataMember] 
        public Guid SupplierDevelopmentTeamGuid
        {
            get => _supplierDevelopmentTeamGuid;
            set =>  _supplierDevelopmentTeamGuid= value;
        }
        private CrudOperationType _crudOperationType;
        [DataMember]
        public CrudOperationType CrudOperationType
        {
            get => _crudOperationType;
            set => _crudOperationType = value;
        }
    }
}
