using Prism.Events;

namespace SEWSE.H1.UX.Infrastructure.Core.Events
{
    public class MessageUpdateEvent : PubSubEvent<MessageUpdateEvent>
    {
        public string Message { get; set; }
    }
}