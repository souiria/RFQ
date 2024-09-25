using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.NPA.Masters
{
    [DataContract, Serializable]
    public class ProductionPartApprovalProcessLevelModel : BaseModel<Guid>
    {

        private string _npaStatusCode;
        [DataMember]
        [StringLength(1)]
        public string LevelCode
        {
            get => _npaStatusCode;
            set => SetProperty(ref _npaStatusCode, value);
        }

        private string _levelDescription = null;
        [DataMember]
        [StringLength(100)]
        public string LevelDescription
        {
            get => _levelDescription;
            set => SetProperty(ref _levelDescription, value);
        }
    }
}
