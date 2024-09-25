using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.Rfq
{
    [DataContract, Serializable]
    public class RFQInformationProcedureModel : ExternalDataSourceModel<object>
    {
        [DataMember, Column(TypeName = "nvarchar")]
        public string TypeDescription { get; set; }
        [DataMember, Column(TypeName = "varchar")]
        public string PartDescription { get; set; }
        [DataMember, Column(TypeName = "varchar")]
        public string PartCategoryCode { get; set; }
        [DataMember, Column(TypeName = "varchar")]
        public string PartCategory { get; set; }
        [DataMember, Column(TypeName = "varchar")]
        public string PartMaterial { get; set; }
        [DataMember, Column(TypeName = "varchar")]
        public string PartMaterialColour { get; set; }
        [DataMember, Column(TypeName = "varchar")]
        public string PartCavityCount { get; set; }
    }
}
