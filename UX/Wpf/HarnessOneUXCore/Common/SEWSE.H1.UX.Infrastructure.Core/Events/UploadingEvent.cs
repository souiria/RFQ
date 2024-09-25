using Prism.Events;
using SEWSE.H1.UX.Infrastructure.Core.Models;

namespace SEWSE.H1.UX.Infrastructure.Core.Events
{   
    public class UploadingEvent : PubSubEvent<bool>
    {
    }
    public class UploadingEvent<T> : PubSubEvent<LoadingSettings> where T : LoadingSettings
    {
    }
}
