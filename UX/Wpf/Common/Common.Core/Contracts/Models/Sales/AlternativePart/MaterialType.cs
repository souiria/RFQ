using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.AlternativePart
{
    [DataContract, Serializable]
    public class MaterialTypes : ExternalDataSourceModel<long>
    {
        [DataMember,  Column("MaterialGroup")]
        public string MaterialGroup { get; set; }
        [DataMember, Key, Column("MaterialType")]
        public string MaterialType { get; set; }
        [DataMember,  Column("TypeDescription")]
        public string TypeDescription { get; set; }
    }
}

