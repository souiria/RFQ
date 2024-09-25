using Common.Core.Contracts.Interfaces.Base;
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.CAE
{
    [DataContract, Serializable]
    public class JH1_11_BranchParts : ExternalDataSourceModel<Guid>
    {
        [DataMember,Key, Column("FileID", Order =1)]
        public int? FileID { get; set; }
        [DataMember,Key, Column("08_NodeA", Order =2)]
        public int? NodeA { get; set; }
        [DataMember,Key, Column("09_NodeB", Order =3)]
        public int? NodeB { get; set; }
        [DataMember,Key, Column("10_PartNo", Order =4)]
        public string PartNo { get; set; }
        [DataMember, Column("11_ManualMHCode")]        
        public string ManualMHCode { get; set; }
        [DataMember, Column("12_OperationCode")]
        public string OperationCode { get; set; }
        [DataMember, Column("13_MHValue")]
        public decimal? MHValue { get; set; }
        [DataMember, Column("14_TemporaryMHFlag")]
        public string TemporaryMHFlag { get; set; }
    }
}
