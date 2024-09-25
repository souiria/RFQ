using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class OriginStatusModel : BaseModel<Guid>
    {
        private string _originStatusCode;
        [DataMember]
        [Required]
        [StringLength(2)]
        public string OriginStatusCode
        {
            get => _originStatusCode;
            set => SetProperty(ref _originStatusCode, value);
        }

        private string _originStatusDescription;
        [DataMember]
        [Required]
        [StringLength(50)]
        public string OriginStatusDescription
        {
            get => _originStatusDescription;
            set => SetProperty(ref _originStatusDescription, value);
        }
    }
}
