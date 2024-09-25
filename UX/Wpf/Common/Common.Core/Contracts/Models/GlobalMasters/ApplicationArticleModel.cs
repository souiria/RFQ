using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class ApplicationArticleModel : BaseModel<Guid>
    {

        private string _articleName;
        [DataMember]
        [StringLength(100)]
        [Required]
        public string ArticleName
        {
            get => _articleName;
            set => SetProperty(ref _articleName, value);
        }

        private string _articleDescription;
        [DataMember]
        [StringLength(500)]
        public string ArticleDescription
        {
            get => _articleDescription;
            set => SetProperty(ref _articleDescription, value);
        }

        private bool _isAdhocSynchronizationEnabled = false;
        [DataMember]
        public bool IsAdhocSynchronizationEnabled
        {
            get => _isAdhocSynchronizationEnabled;
            set => SetProperty(ref _isAdhocSynchronizationEnabled, value);
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
