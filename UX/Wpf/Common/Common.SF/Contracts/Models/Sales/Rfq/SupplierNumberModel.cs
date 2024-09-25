using System;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;

namespace Common.SF.Contracts.Models.Sales.Rfq
{
    [DataContract, Serializable]
    public class SupplierNumberModel : ExternalDataSourceModel<object>
    {
        [DataMember]
        public string SumitomoNumber { get; set; }
        [DataMember]
        public string SupplierNumber { get; set; }
    }
}
