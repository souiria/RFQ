using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class IncotermsModel : BaseModel<Guid>
    {
        private string _incotermCode;
        [DataMember]
        [Required]
        [StringLength(3)]
        public string IncotermCode
        {
            get => _incotermCode;
            set => SetProperty(ref _incotermCode, value);
        }

        private string _incotermDescription;
        [DataMember]
        [Required]
        [StringLength(50)]
        public string IncotermDescription
        {
            get => _incotermDescription;
            set => SetProperty(ref _incotermDescription, value);
        }
        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }
    }
}
