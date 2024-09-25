using Common.Core.Contracts.Models.Core.Notifications;

namespace Common.SF.Contracts.Models.Core.Notifications
{
    public class NotificationChannelPair
    {
        public Notification Notification { get; set; }
        public string Channel { get; set; }
    }
}
