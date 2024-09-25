using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class PurchasingArticleSynchronizationModel : BaseModel<Guid>
    {
        private Guid _businessUnitGuid;
        [DataMember]
        [Required]
        public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => SetProperty(ref _businessUnitGuid, value);
        }

        private Guid _applicationArticleGuid;
        [DataMember]
        [Required]
        public Guid ApplicationArticleGuid
        {
            get => _applicationArticleGuid;
            set => SetProperty(ref _applicationArticleGuid, value);
        }

        private DateTime _lastSynchronizeDateTime;
        [DataMember]
        public DateTime LastSynchronizeDateTime
        {
            get => _lastSynchronizeDateTime;
            set => SetProperty(ref _lastSynchronizeDateTime, value);
        }

        private Guid _lastSynchronizeBy;
        [DataMember]
        public Guid LastSynchronizeBy
        {
            get => _lastSynchronizeBy;
            set => SetProperty(ref _lastSynchronizeBy, value);
        }

        private string _synchronizationStatus;
        [DataMember]
        [StringLength(1)]
        public string SynchronizationStatus
        {
            get => _synchronizationStatus;
            set => SetProperty(ref _synchronizationStatus, value);
        }
        private string _remarks;
        [DataMember]
        public string Remarks
        {
            get => _remarks;
            set => SetProperty(ref _remarks, value);
        }
    }
}
