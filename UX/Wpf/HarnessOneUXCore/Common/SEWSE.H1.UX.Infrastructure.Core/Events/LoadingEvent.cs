using Prism.Events;
using SEWSE.H1.UX.Infrastructure.Core.Models;

namespace SEWSE.H1.UX.Infrastructure.Core.Events
{
    public class LoadingEvent : PubSubEvent<bool>
    {
    }

    public class LoadingEvent<T> : PubSubEvent<LoadingSettings> where T : LoadingSettings
    {
    }
}
