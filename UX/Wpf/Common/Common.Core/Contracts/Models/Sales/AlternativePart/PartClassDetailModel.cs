using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.AlternativePart
{
    [DataContract, Serializable]
    public class PartClassDetailModel : ExternalDataSourceModel<long>
    {
        [DataMember, Key, Column(Order = 0)]
        public string Class1 { get; set; }
        [DataMember]
        public string Class1Name { get; set; }
        [DataMember, Key, Column(Order = 1)]
        public double? Class2 { get; set; }
        [DataMember]
        public string Class2Name { get; set; }
        [NotMapped]
        public string DisplayClass1 => Class1 + " : " + Class1Name;
        [NotMapped]
        public string DisplayClass2 => Class2 + " : " + Class2Name;
    }
}
