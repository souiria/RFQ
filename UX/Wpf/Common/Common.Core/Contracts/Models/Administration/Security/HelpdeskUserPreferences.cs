using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Administration.Security
{
    [DataContract, Serializable]
    public class HelpdeskUserPreferences : ExternalDataSourceModel<object>
    {
        //TODO: Rename Cn to a more understandable name. Leave the column attribute as it is.
        [DataMember, Column("Cn"), Key]
        public string Cn { get; set; }
        [DataMember]
        [Column("PreferredApprover")]
        public string PreferredApprover { get; set; }
    }
}
