using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.ETL.NPA
{
    [DataContract, NotMapped, Serializable]
    public class TemporaryNpaUploadModel
    {
        [DataMember, NotMapped]
        public DateTime Raise_Date { get; set; }

        [DataMember, NotMapped]
        public int Material_Type { get; set; }

        [DataMember, NotMapped]
        public string Sumitomo_No { get; set; }

        [DataMember, NotMapped]
        public string Replaced_Part { get; set; }

        [DataMember, NotMapped]
        public string Name { get; set; }

        [DataMember, NotMapped]
        public string Description { get; set; }

        [DataMember, NotMapped]
        public string Supplier_No { get; set; }

        [DataMember, NotMapped]
        public string Suggested_Supplier { get; set; }

        [DataMember, NotMapped]
        public string Project { get; set; }

        [DataMember, NotMapped]
        public string Customer { get; set; }

        [DataMember, NotMapped]
        public string Customer_No { get; set; }

        [DataMember, NotMapped]
        public string Assembly_No { get; set; }

        [DataMember, NotMapped]
        public string UOM { get; set; }

        [DataMember, NotMapped]
        public double Qty_Per_Vehicle { get; set; }

        [DataMember, NotMapped]
        public double Copper_Weight { get; set; }

        [DataMember, NotMapped]
        public string Eng_Comments { get; set; }

        [DataMember, NotMapped]
        public string Reason { get; set; }

        [DataMember, NotMapped]
        public int Record_Number { get; set; }

        [DataMember, NotMapped]
        public string LoggedInUser { get; set; }

        [DataMember, NotMapped]
        public string Subsidiary_Name { get; set; }
    }
}
