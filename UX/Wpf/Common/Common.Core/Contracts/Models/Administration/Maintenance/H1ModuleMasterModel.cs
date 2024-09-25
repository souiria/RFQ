using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Administration.Maintenance
{
    [DataContract, Serializable]
    public class H1ModuleMasterModel : BaseModel<Guid>
    {
        private string _moduleName;
        [DataMember]
        [Required]
        [StringLength(50)]
        public string ModuleName
        {
            get => _moduleName;
            set => SetProperty(ref _moduleName, value);
        }

        //Adam - 08/01/2018 - Added in order to allow security to query by the Active directory name to retrieve the correct modules
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
