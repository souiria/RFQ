using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Administration.Maintenance
{
    [DataContract, Serializable]
    public class H1FunctionMasterModel : BaseModel<Guid>
    {
        private string _functionName;
        [DataMember]
        [StringLength(50)]
        public string FunctionName
        {
            get => _functionName;
            set => SetProperty(ref _functionName, value);
        }

        private string _activeDirectoryName;
        [DataMember]
        [Required]
        public string ActiveDirectoryName
        {
            get => _activeDirectoryName;
            set => SetProperty(ref _activeDirectoryName, value);
        }
    }
}
