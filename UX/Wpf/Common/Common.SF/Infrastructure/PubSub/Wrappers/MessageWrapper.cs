using System;
using System.Runtime.Serialization;
using DefaultPayloadSerializer = Common.SF.Infrastructure.PubSub.Serializers.DefaultPayloadSerializer;
using IPayloadSerializer = Common.SF.Infrastructure.PubSub.Serializers.IPayloadSerializer;

namespace Common.SF.Infrastructure.PubSub.Wrappers
{
    /// <summary>
    /// Generic message format. Contains message CLR type (full name) and serialized payload. If you know the Message Type you can deserialize 
    /// the payload into that object.
    /// </summary>
    [DataContract, Serializable]
    public partial class MessageWrapper
    {
        /// <summary>
        /// Indicates whether this message was relayed.
        /// </summary>
        [DataMember]
        public bool IsRelayed { get; set; }

        /// <summary>
        /// The string the payload was sent using
        /// </summary>
        [DataMember]
        public string Channel { get; set; }

        /// <summary>
        /// Serialized object.
        /// </summary>
        [DataMember]
        public string Payload { get; set; }
    }

    public partial class MessageWrapper
    {
        /// <summary>
        /// Gets or sets the <see cref="IPayloadSerializer"/> to use when setting the <see cref="Payload"/>. Defaults to <see cref="DefaultPayloadSerializer"/> which uses Json.Net.
        /// </summary>
        public static IPayloadSerializer PayloadSerializer { get; set; } = new DefaultPayloadSerializer();

        /// <summary>
        /// Convert the provided <paramref name="message"/> into a <see cref="MessageWrapper"/>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="channel"></param>
        /// <returns></returns> 
        public static MessageWrapper CreateMessageWrapper(object message, string channel)
        {
            var wrapper = new MessageWrapper
            {
                Channel = channel,
                Payload = (PayloadSerializer ?? new DefaultPayloadSerializer()).Serialize(message),
            };
            return wrapper;
        }
    }

}
