using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.Administration.Maintenance
{
    public class UXRegionsModel: BaseModel<Guid>
    {
        private bool? _isRowChecked = false;
        [NotMapped, DataMember]
        public bool? IsRowChecked
        {
            get => _isRowChecked;
            set => SetProperty(ref _isRowChecked, value);
        }

        private string _regionName;
        [DataMember]
        [Required]
        [StringLength(50)]
        public string RegionName
        {
            get => _regionName;
            set => SetProperty(ref _regionName, value);
        }
    }
}
