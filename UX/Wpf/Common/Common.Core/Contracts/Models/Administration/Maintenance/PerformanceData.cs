using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.Administration.Maintenance
{
    [DataContract, Serializable]
    public class PerformanceData : BaseModel<Guid>
    {
        private string _eventType;
        private string _event;
        private string _time;

        [DataMember]
        public string EventType
        { get => _eventType; set => SetProperty(ref _eventType, value); }

        [DataMember]
        public string Event
        { get => _event; set => SetProperty(ref _event, value); }

        [DataMember]
        public string Time { get => _time; set => SetProperty(ref _time, value); }
    }
}

