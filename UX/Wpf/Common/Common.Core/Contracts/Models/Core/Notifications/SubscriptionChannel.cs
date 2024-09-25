using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Core.Notifications
{
    [DataContract, Serializable]
    public class SubscriptionChannel : BindableBaseEntity, IEquatable<string>, IEquatable<SubscriptionChannel>,
        IComparable<SubscriptionChannel>, IComparable<string>
    {
        private string _channel;
        [DataMember]
        public string Channel
        {
            get => _channel;
            set => SetProperty(ref _channel, value);
        }

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

        private string _description;
        [DataMember]
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        private string _eventType;
        [DataMember]
        public string EventType
        {
            get => _eventType;
            set => SetProperty(ref _eventType, value);
        }

        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }

        private bool _isChecked;
        [DataMember]
        public bool IsChecked
        {
            get => _isChecked;
            set => SetProperty(ref _isChecked, value);
        }

        private CrudOperationType _crudOperationType;
        [NotMapped, DataMember]
        public CrudOperationType CrudOperationType
        {
            get => _crudOperationType;
            set => SetProperty(ref _crudOperationType, value);
        }

        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case SubscriptionChannel objChannel:
                    return Equals(objChannel);

                case string stringChannel:
                    return Equals(stringChannel);

                default:
                    return false;
            }
        }

        public bool Equals(SubscriptionChannel other)
        {
            return Channel.Equals(other.Channel);
        }

        public bool Equals(string other)
        {
            return Channel.Equals(other);
        }

        public override int GetHashCode()
        {
            return Channel.GetHashCode();
        }

        public int CompareTo(SubscriptionChannel other)
        {
            return string.CompareOrdinal(Channel, other.Channel);
        }

        public int CompareTo(string other)
        {
            return string.CompareOrdinal(Channel, other);
        }
    }
}
