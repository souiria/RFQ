using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMastersAssociation
{
    [DataContract, Serializable]
    public   class SupplierAssociationGridDataModel 
    {
        [DataMember]
        public string SupplierCode { get; set; }

        [DataMember]
        public string SupplierGroupName { get; set; }

        [DataMember]
        public string SupplierTypeName { get; set; }

        [DataMember]
        public string IncoTermsCode { get; set; }

        [DataMember]
        public string CurrencyCode { get; set; }

        [DataMember]
        public string BuyerName { get; set; }

        [DataMember]
        public string SDECode { get; set; }

        [DataMember]
        public Guid SupplierGuid { get; set; }

        [DataMember]
        public Guid SupplierTypeGuid { get; set; }

        [DataMember]
        public Guid SupplierGroupGuid { get; set; }

        [DataMember]
        public Guid SupplierIncoTermsGuid { get; set; }

        [DataMember]
        public Guid SupplierCurrencyGuid { get; set; }

        [DataMember]
        public Guid SupplierBuyerGuid { get; set; }

        [DataMember]
        public Guid SupplierTransporterCurrencyGuid { get; set; }

        [DataMember]
        public Guid SupplierDevelopmentTeamGuid { get; set; }

        [DataMember]
        public CrudOperationType CrudOperationType { get; set; }

        [DataMember]
        public Guid SupplierAssociationGuid { get; set; }
    }
}
