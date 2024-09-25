using Common.Core.Contracts.Interfaces.Base;
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.CAE
{
    [DataContract, Serializable]
    public class JH1_10_LeadParts : ExternalDataSourceModel<Guid>
    {
        [DataMember,Key, Column("FileID", Order = 0)]
        public int? FileID { get; set; }
        [DataMember,Key, Column("08_EndNoA", Order = 1)]
        public string EndNoA { get; set; }
        [DataMember, Key, Column("09_EndNoB", Order = 2)]
        public string EndNoB { get; set; }
        [DataMember,Key, Column("10_PartNo", Order = 3)]
        public string PartNo { get; set; }
        [DataMember, Column("11_CompositionFlag")]
        public string PartCompositionFlag { get; set; }
        [DataMember, Column("12_ManualMHCode")]
        public string ManualMHCode { get; set; }
        [DataMember, Column("13_OperationCode")]
        public string OperationCode { get; set; }
        [DataMember, Column("14_MHValue")]
        public decimal? MHValue { get; set; }
        [DataMember, Column("15_TemporaryMHFlag")]
        public string TemporaryMHFlag { get; set; }
    }
}
