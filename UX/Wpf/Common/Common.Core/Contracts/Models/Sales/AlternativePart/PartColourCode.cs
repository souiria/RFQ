using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.AlternativePart
{
    [DataContract, Serializable]
    public class PartColourCode : ExternalDataSourceModel<long>
    {
        [DataMember, Key]
        public string ClMk { get; set;}
        [DataMember]
        public string ClCode { get; set;}
        [DataMember]
        public string ColorName { get; set; }
        [DataMember]
        public int WireUnitsFlag { get; set; }
        [DataMember]
        public int PartUnitsFlag { get; set; }
        [NotMapped]
        public string Display { get { return ClMk + " - " + ColorName; } }
    }
}
