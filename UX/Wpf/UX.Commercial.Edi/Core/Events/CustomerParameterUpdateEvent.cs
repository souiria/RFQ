using Prism.Events;
using UX.Commercial.Edi.Core.Messages;

namespace UX.Commercial.Edi.Core.Events
{
    internal class CustomerParameterUpdateEvent : PubSubEvent<UpdateMessage> { }
}
