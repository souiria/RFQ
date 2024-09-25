using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class ETLPurchasingArticleSynchronizationGridModel : BaseModel<Guid>
    {
        #region Properties
        private Guid _purchasingArticleSynchronizationGuid;
        [DataMember]
        public Guid PurchasingArticleSynchronizationGuid
        {
            get => _purchasingArticleSynchronizationGuid;
            set => SetProperty(ref _purchasingArticleSynchronizationGuid, value);
        }

        private string _businessUnitCode;
        [DataMember]
        public string BusinessUnitCode
        {
            get => _businessUnitCode;
            set => SetProperty(ref _businessUnitCode, value);
        }
        private string _businessUnitName;
        [DataMember]
        public string BusinessUnitName
        {
            get => _businessUnitName;
            set => SetProperty(ref _businessUnitName, value);
        }

        private string _articleName;
        [DataMember]
        public string ArticleName
        {
            get => _articleName;
            set => SetProperty(ref _articleName, value);
        }
        private string _articleDescription;
        [DataMember]
        public string ArticleDescription
        {
            get => _articleDescription;
            set => SetProperty(ref _articleDescription, value);
        }
        private string _synchronizeByName;
        [DataMember]
        public string SynchronizeByName
        {
            get => _synchronizeByName;
            set => SetProperty(ref _synchronizeByName, value);
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


        #endregion
    }
}
