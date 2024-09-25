using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Core.Filtering
{
    [DataContract, NotMapped]
    public class InternalFilterModel
    {
        [DataMember, NotMapped]
        public string FilterProperty { get; set; }
        [DataMember, NotMapped]
        public string FilterValue { get; set; }
        [DataMember, NotMapped]
        public bool IsAnd { get; set; } = false;
    }
}
