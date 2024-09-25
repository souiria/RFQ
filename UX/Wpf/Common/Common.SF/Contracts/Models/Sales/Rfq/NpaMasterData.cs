using System;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;

namespace Common.SF.Contracts.Models.Sales.Rfq
{
    [DataContract, Serializable]
    public class NpaMasterData : ExternalDataSourceModel<object>
    {
        [DataMember]
        public string NpaId { get; set; }
        [DataMember]
        public string NpaName { get; set; }
        [DataMember]
        public string NpaCode { get; set; }
    }
}
