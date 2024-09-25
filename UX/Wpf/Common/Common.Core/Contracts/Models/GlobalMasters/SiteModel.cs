using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class SiteModel : BaseModel<Guid>
    {
        private bool? _isRowChecked = false;
        [NotMapped, DataMember]
        public bool? IsRowChecked
        {
            get => _isRowChecked;
            set => SetProperty(ref _isRowChecked, value);
        }

        private string _shortCode;
        [DataMember]
        [Required]
        [StringLength(1)]
        public string ShortCode
        {
            get => _shortCode;
            set => SetProperty(ref _shortCode, value);
        }

        private string _siteName;
        [DataMember]
        [Required]
        [StringLength(50)]
        public string SiteName
        {
            get => _siteName;
            set => SetProperty(ref _siteName, value);
        }

        private Guid siteTypeGuid;
        [DataMember]
        [Required]
        public Guid SiteTypeGuid
        {
            get => siteTypeGuid;
            set => SetProperty(ref siteTypeGuid, value);
        }

        private bool _isActive = true;
        [DataMember]
        [Required]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }

    }
}
