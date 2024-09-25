using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.AlternativePart
{
    [DataContract, Serializable]
    public class PartCategoryDetailModel:ExternalDataSourceModel<long>
    {
        [DataMember,Key, Column("Category Code")]
        public string CategoryCode { get; set; }
        [DataMember, Column("Detailed Category Code")]
        public double? DetailedCategoryCode { get; set; }
        [DataMember, Column("Category Name")]
        public string CategoryName { get; set; }

        [NotMapped]
        public string Display => CategoryCode + " : " + CategoryName;
    }
}
