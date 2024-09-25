using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UX.Module.Edi.Core.Messages;

namespace UX.Module.Edi.Core.Events
{
    internal class CustomerParameterUpdateEvent : PubSubEvent<UpdateMessage> { }
}
