using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMastersAssociation
{
    [DataContract, Serializable]
   public class BusinessUnitGIStoreAssociationModel : BaseModel<Guid>
    {

        private Guid _businessUnitGuid;
        [DataMember]
        [Required]
        public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => SetProperty(ref _businessUnitGuid, value);
        }

        private Guid _giStoreGuid;
        [DataMember]
        [Required]
        public Guid GIStoreGuid
        {
            get => _giStoreGuid;
            set => SetProperty(ref _giStoreGuid, value);
        }

        private string _qualityNotificationEmailId;
        /// <summary>
        /// Maintain multiple Email Details for Quality Team
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(200)]
        public string QualityNotificationEmailId
        {
            get => _qualityNotificationEmailId;
            set => SetProperty(ref _qualityNotificationEmailId, value);
        }

        private string _logisticNotificationEmailId;
        /// <summary>
        /// Maintain multiple Email Details for Logistic Team
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(200)]
        public string LogisticNotificationEmailId
        {
            get => _logisticNotificationEmailId;
            set => SetProperty(ref _logisticNotificationEmailId, value);
        }


    }
}
