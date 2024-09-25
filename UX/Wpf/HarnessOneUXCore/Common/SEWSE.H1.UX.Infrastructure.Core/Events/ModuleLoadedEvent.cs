using Prism.Events;

namespace SEWSE.H1.UX.Infrastructure.Core.Events
{
    public class ModuleLoadedEvent : PubSubEvent<ModuleLoadedEvent>
    {
        public string Message { get; set; }
    }
}