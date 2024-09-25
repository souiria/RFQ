using Prism.Events;
using SEWSE.H1.UX.Infrastructure.Core.Models;

namespace SEWSE.H1.UX.Infrastructure.Core.Events
{
    public class StatusBarNotificationChangedEvent : PubSubEvent<UXStatusBarNotification> { }
}
