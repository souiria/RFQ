using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    public class LogisticsConcernRaisedStatusModel : BaseModel<Guid>
    {
        private string _statusCode;
        [DataMember]
        [Required]
        [StringLength(50)]
        public string StatusCode
        {
            get => _statusCode;
            set => SetProperty(ref _statusCode, value);
        }
        private string _statusDescription;
        [DataMember]
        [StringLength(500)]
        public string StatusDescription
        {
            get => _statusDescription;
            set => SetProperty(ref _statusDescription, value);
        }
    }
}
