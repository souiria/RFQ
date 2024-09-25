using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class ToolOwnerModel : BaseModel<Guid>
    {
        private string toolOwnerName;
        [DataMember]
        [Required]
        [StringLength(500)]
        public string ToolOwnerName
        {
            get => toolOwnerName;
            set => SetProperty(ref toolOwnerName, value);
        }
        private string toolDescription;
        [DataMember]
        [StringLength(500)]
        public string ToolDescription
        {
            get => toolDescription;
            set => SetProperty(ref toolDescription, value);
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
