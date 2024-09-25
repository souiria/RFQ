using Common.Core.Contracts.Interfaces.Base;
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.CAE
{
    [DataContract, Serializable]
    public class JH1_14_ConnectorAttachments : ExternalDataSourceModel<Guid>
    {
        [DataMember,Key, Column("FileID", Order =0)]
        public int FileID { get; set; }
        [DataMember,Key, Column("08_NodeNo", Order =1)]
        public int NodeNo { get; set; }
        [DataMember,Key, Column("09_PartNo", Order =2)]
        public string PartNo { get; set; }
        [DataMember, Column("10_ManualMHCode")]
        public string ManualMHCode { get; set; }
        [DataMember, Column("11_OperationCode")]
        public string OperationCode { get; set; }
        [DataMember, Column("12_MHValue")]
        public decimal MHValue { get; set; }
        [DataMember, Column("13_TemporaryMHFlag")]
        public string TemporaryMHFlag { get; set; }
    }
}
