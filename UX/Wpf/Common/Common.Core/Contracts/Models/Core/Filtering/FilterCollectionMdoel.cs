using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Core.Filtering
{
    [DataContract, NotMapped]
    public class FilterCollectionModel
    {
        [DataMember, NotMapped]
        public IEnumerable<InternalFilterModel> InternalFilterCollection { get; set; }
        [DataMember, NotMapped]
        public bool IsAnd { get; set; } = false;
    }
}
