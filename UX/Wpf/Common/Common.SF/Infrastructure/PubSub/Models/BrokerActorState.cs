using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Common.SF.Infrastructure.PubSub.Wrappers;

namespace Common.SF.Infrastructure.PubSub.Models
{
    /// <summary>
    /// State for <see cref="BrokerActor"/>. Contains a regular queue and a dead letter queue for every registered listener.
    /// </summary>
    [DataContract, Serializable]
    public sealed class BrokerActorState
    {
        /// <summary>
        /// Contains messages that could not be be sent to subscribed listeners. (has a limit)
        /// </summary>
        [DataMember]
        public Dictionary<ReferenceWrapper, Queue<MessageWrapper>> SubscriberDeadLetters { get; set; }

        /// <summary>
        /// Contains messages to be sent to subscribed listeners.
        /// </summary>
        [DataMember]
        public Dictionary<ReferenceWrapper, Queue<MessageWrapper>> SubscriberMessages { get; set; }
    }

}
