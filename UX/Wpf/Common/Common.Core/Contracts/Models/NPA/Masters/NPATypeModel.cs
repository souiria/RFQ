using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.NPA.Masters
{
    [DataContract, Serializable]
    public class NPATypeModel : BaseModel<Guid>
    {
        private string _npaTypeCode;
        [DataMember]
        [StringLength(10)]
        public string NPATypeCode
        {
            get => _npaTypeCode;
            set => SetProperty(ref _npaTypeCode, value);
        }

        private string _npaTypeDescription = null;
        [DataMember]
        [StringLength(50)]
        public string NPATypeDescription
        {
            get => _npaTypeDescription;
            set => SetProperty(ref _npaTypeDescription, value);
        }
    }
}
