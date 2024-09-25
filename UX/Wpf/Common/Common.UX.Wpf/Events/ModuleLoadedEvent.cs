using Prism.Events;

namespace Common.UX.Wpf.Events
{
    public class ModuleLoadedEvent : PubSubEvent<ModuleLoadedEvent>
    {
        public string Message { get; set; }
    }
}