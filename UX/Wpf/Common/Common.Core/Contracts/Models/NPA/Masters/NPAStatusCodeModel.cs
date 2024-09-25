using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.NPA.Masters
{
    [DataContract, Serializable]
    public class NPAStatusCodeModel : BaseModel<Guid>
    {

        private string _npaStatusCode;
        [DataMember]
        [StringLength(4)]
        public string NPAStatusCode
        {
            get => _npaStatusCode;
            set => SetProperty(ref _npaStatusCode, value);
        }

        private string _npaStatusDescription = null;
        [DataMember]
        [StringLength(100)]
        public string NPAStatusDescription
        {
            get => _npaStatusDescription;
            set => SetProperty(ref _npaStatusDescription, value);
        }
    }
}
