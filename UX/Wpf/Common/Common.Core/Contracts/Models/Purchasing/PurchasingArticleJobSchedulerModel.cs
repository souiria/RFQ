using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
   public  class PurchasingArticleJobSchedulerModel : BaseModel<Guid>
    {
        private Guid _articleGuid;
        [DataMember]
        [Required]
        public Guid ArticleGuid
        {
            get => _articleGuid;
            set => SetProperty(ref _articleGuid, value);
        }
        private long _noOfHours;
        [DataMember]
        public long NoOfHours
        {
            get => _noOfHours;
            set => SetProperty(ref _noOfHours, value);
        }
        private bool _jobEnabled = true;
        [DataMember]
        public bool JobEnabled
        {
            get => _jobEnabled;
            set => SetProperty(ref _jobEnabled, value);
        }
       
    }
}
