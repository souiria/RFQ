using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.AlternativePart
{
    [DataContract, Serializable]
    public class MaterialGroups : ExternalDataSourceModel<long>
    {
        [DataMember, Key, Column("MaterialGroup")]
        public string MaterialGroup { get; set; }
        [DataMember, Column("GroupDescription")]
        public string GroupDescription { get; set; }
    }
}

