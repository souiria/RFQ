using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class PurchasingArticleJobDetailsModel : BaseModel<Guid>
    {
        private Guid _applicationArticleGuid;
        [DataMember]
        [Required]
        public Guid ApplicationArticleGuid
        {
            get => _applicationArticleGuid;
            set => SetProperty(ref _applicationArticleGuid, value);
        }
        private DateTime ? _jobStartTime;
        [DataMember]
        public DateTime ? JobStartTime
        {
            get => _jobStartTime;
            set => SetProperty(ref _jobStartTime, value);
        }
        private DateTime ? _jobEndTime;
        [DataMember]
        public DateTime ? JobEndTime
        {
            get => _jobEndTime;
            set => SetProperty(ref _jobEndTime, value);
        }

        private string _remarks;
        [DataMember]
        [StringLength(1000)]
        public string Remarks
        {
            get => _remarks;
            set => SetProperty(ref _remarks, value);
        }
    }
}
