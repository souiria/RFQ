using Prism.Mvvm;
using System;
using System.Timers;

namespace Common.UX.Wpf.Contracts.Models
{
    public class UXStatusBarNotification : BindableBase
    {
        private string _message;
        /// <summary>
        /// Message to be displayed in the status bar
        /// </summary>
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }
        private string _statusColor;
        /// <summary>
        /// Color of the status bar according to the message type.
        /// </summary>
        public string StatusColor
        {
            get => _statusColor;
            set => SetProperty(ref _statusColor, value);
        }
        private UXNotificationType _statusType;
        /// <summary>
        /// Type of message in the status bar.
        /// </summary>
        public UXNotificationType StatusType
        {
            get => _statusType;
            set => SetProperty(ref _statusType, value);
        }

        private int _progress = 5;
        /// <summary>
        /// Progress bar progress
        /// </summary>
        public int Progress
        {
            get => _progress;
            set => SetProperty(ref _progress, value);
        }

        private Timer ExpiryTimer;

        private void Timer()
        {
            ExpiryTimer = new System.Timers.Timer(1000);
            ExpiryTimer.Elapsed += TimedEvent;
            ExpiryTimer.AutoReset = true;
            ExpiryTimer.Enabled = true;
        }

        private void TimedEvent(Object source, ElapsedEventArgs e)
        {
            if (Progress > 0)
                Progress--;
            else
                ExpiryTimer.Stop();
        }

        public UXStatusBarNotification()
        {
            Timer();
        }
    }
}
