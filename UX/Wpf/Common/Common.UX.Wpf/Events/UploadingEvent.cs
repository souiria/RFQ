using Common.UX.Wpf.Contracts.Models;
using Prism.Events;

namespace Common.UX.Wpf.Events
{   
    public class UploadingEvent : PubSubEvent<bool>
    {
    }
    public class UploadingEvent<T> : PubSubEvent<LoadingSettings> where T : LoadingSettings
    {
    }
}
