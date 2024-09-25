using Common.Core.Contracts.Interfaces.Base;
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.CAE
{
    [DataContract, Serializable]
    public class JH1_0_CommonData : ExternalDataSourceModel<Guid>
    {
        [DataMember, Column("FileID"), Key]
        public int FileID { get; set; }
        [DataMember, Column("01_CustomerCode")]
        public string CustomerCode { get; set; }
        [DataMember, Column("02_ProductNo")]
        public string ProductNo { get; set; }
        [DataMember, Column("03_DesignChange")]
        public string DesignChange{ get; set; }
    [DataMember, Column("04_AreaCode")]
        public string AreaCode { get; set; }
        [DataMember, Column("05_MHYear")]
        public string MHYear { get; set; }
        [DataMember, Column("06_MHCode")]
        public string MHCode { get; set; }
    }
}
