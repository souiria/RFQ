using System;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;

namespace Common.SF.Contracts.Models.Sales.Rfq
{
    [DataContract, Serializable]
    public class CustomerMasterData : ExternalDataSourceModel<object>
    {
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public string CustomerCode { get; set; }
        [DataMember]
        public string CustomerGroup { get; set; }
    }
}
