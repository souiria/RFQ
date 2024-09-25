using Common.UX.Wpf.Contracts.Models;
using Prism.Events;

namespace Common.UX.Wpf.Events
{
    public class StatusBarNotificationChangedEvent : PubSubEvent<UXStatusBarNotification> { }
}
