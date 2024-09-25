using System;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;

namespace Common.SF.Contracts.Models.Sales.Rfq
{
    [DataContract, Serializable]
    public class NpaMaterialOriginModel : ExternalDataSourceModel<object>
    {
        [DataMember]
        public string SumitomoNumber { get; set; }
        [DataMember]
        public string Currency { get; set; }
    }
}
