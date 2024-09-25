using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.ETL.NPA
{
    [DataContract, Serializable]

    public class NpaUomModel : ExternalDataSourceModel<Guid>
    {
        [DataMember, Key]
        public long id { get; set; }
        [DataMember]
        public string abbreviation { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public long subsidiary_id { get; set; }
    }
}
