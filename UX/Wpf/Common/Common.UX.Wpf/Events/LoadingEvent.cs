using Common.UX.Wpf.Contracts.Models;
using Prism.Events;

namespace Common.UX.Wpf.Events
{
    public class LoadingEvent : PubSubEvent<bool>
    {
    }

    public class LoadingEvent<T> : PubSubEvent<LoadingSettings> where T : LoadingSettings
    {
    }
}
