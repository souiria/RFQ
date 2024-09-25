using Prism.Mvvm;

namespace SEWSE.H1.UX.Infrastructure.Core.Models
{
    public class UXStatusBarNotification : BindableBase
    {
        private string _message;
        /// <summary>
        /// Message to be displayed in the status bar
        /// </summary>
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }
        private string _statusColor;
        /// <summary>
        /// Color of the statusbar according to the messagetype.
        /// </summary>
        public string StatusColor
        {
            get { return _statusColor; }
            set { SetProperty(ref _statusColor, value); }
        }
        private UXNotificationType _statusType;
        /// <summary>
        /// Type of message in the status bar.
        /// </summary>
        public UXNotificationType StatusType
        {
            get { return _statusType; }
            set { SetProperty(ref _statusType, value); }
        }

        private int _progress = 0;
        /// <summary>
        /// Progress bar progress
        /// </summary>
        public int Progress
        {
            get { return _progress; }
            set { SetProperty(ref _progress, value); }
        }
    }
}
