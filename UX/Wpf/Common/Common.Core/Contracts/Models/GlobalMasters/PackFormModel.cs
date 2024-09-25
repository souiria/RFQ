using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class PackFormModel : BaseModel<Guid>
    {

        private string _packFormName;
        [DataMember]
        [Required]
        [StringLength(30)]
        public string PackFormName
        {
            get => _packFormName;
            set => SetProperty(ref _packFormName, value);
        }
    }
}
