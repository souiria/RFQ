using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.Core.Settings
{
    [DataContract, Serializable]
    public class H1ServiceConfigurationSettingJSONModel  : BaseModel<Guid>
    {
        private string _modelData;
        [DataMember]
        public string ModelData
        {
            get => _modelData;
            set => _modelData = value;
        }
        private bool _isActive = true;
        [NotMapped, DataMember]
        public virtual bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }
        [NotMapped, DataMember]
        public DateTime CreatedDate
        {
            get;
            set;
        }

        [NotMapped,DataMember]
        public DateTime ModifiedDate
        {
            get;
            set;
        }

        [NotMapped,DataMember]
        public Guid CreatedBy
        {
            get;
            set;
        }

        [NotMapped,DataMember]
        public Guid ModifiedBy
        {
            get;
            set;
        }
    }
}
