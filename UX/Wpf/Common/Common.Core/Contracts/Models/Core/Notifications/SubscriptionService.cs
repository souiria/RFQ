using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Core.Notifications
{
    public class SubscriptionService : BaseModel<Guid>
    {
        private string _functionName;
        [DataMember]
        public string FunctionName
        {
            get => _functionName;
            set => SetProperty(ref _functionName, value);
        }


        private string _serviceName;
        [DataMember]
        public string ServiceName
        {
            get => _serviceName;
            set => SetProperty(ref _serviceName, value);
        }

        private List<SubscriptionChannel> _channels;
        [DataMember]
        public List<SubscriptionChannel> Channels
        {
            get => _channels;
            set => SetProperty(ref _channels, value);
        }
    }
}
