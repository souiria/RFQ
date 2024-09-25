using Prism.Events;

namespace Common.UX.Wpf.Events
{
    public class MessageUpdateEvent : PubSubEvent<MessageUpdateEvent>
    {
        public string Message { get; set; }
    }
}