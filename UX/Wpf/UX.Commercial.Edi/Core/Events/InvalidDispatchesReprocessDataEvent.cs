using Prism.Events;
using UX.Commercial.Edi.Core.Messages;

namespace UX.Commercial.Edi.Core.Events
{
    public class InvalidDispatchesReprocessDataEvent : PubSubEvent<ProcessDataMessage> { }
}
