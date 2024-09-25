using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.Sales.AlternativePart
{
    [DataContract,Serializable]
    public class AlternativePartProject : BaseModel<Guid>
    {
        [DataMember]
        public Guid? ID { get; set; }
        [DataMember]
        public string ProjectName { get; set; }
        [DataMember]
        public string BoM { get; set; }
        [DataMember]
        public DateTime CreateTime { get; set; }
        [DataMember]
        public List<AlternativePartSwap> PartList { get; set; }
    }
}
