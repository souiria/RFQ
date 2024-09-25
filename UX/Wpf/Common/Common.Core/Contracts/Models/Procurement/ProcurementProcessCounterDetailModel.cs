using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Procurement
{
    [DataContract, Serializable]
    public class ProcurementProcessCounterDetailModel : BaseModel<Guid>
    {
        private Guid _siteGuid;
        [DataMember]
        public Guid SiteGuid
        {
            get => _siteGuid;
            set => SetProperty(ref _siteGuid, value);
        }

        private Guid _counterKeyGuid;
        [DataMember]
        public Guid CounterKeyGuid
        {
            get => _counterKeyGuid;
            set => SetProperty(ref _counterKeyGuid, value);
        }

        private Guid _prefixCodeGuid;
        [DataMember]
        public Guid PrefixCodeGuid
        {
            get => _prefixCodeGuid;
            set => SetProperty(ref _prefixCodeGuid, value);
        }

        private int _counter;
        [DataMember]
        [Required]
        public int Counter
        {
            get => _counter;
            set => SetProperty(ref _counter, value);
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
