using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Common.UX.Wpf.Contracts.Interfaces;
using Common.UX.Wpf.Contracts.Models;
using Common.UX.Wpf.Events;
using Prism.Events;

namespace Common.UX.Wpf.Helpers
{
    public class StatusBarMessageHelper : IStatusBarMessageHelper
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly int _actionDelay;
        public StatusBarMessageHelper(IEventAggregator eventAggregator)
        {
            _actionDelay = 10;
            _eventAggregator = eventAggregator;
        }
        #region Display messages
        /// <summary>
        /// Display statusbar message for the validation, exception or any other event.
        /// </summary>
        /// <param name="message">Actual content of the message.</param>
        /// <param name="operationName">Name of the current operation.</param>
        /// <param name="messageType">ActionNames.MessageType</param>
        public async void DisplayMessage(string message, string operationName, UXNotificationType messageType)
        {
            try
            {
                Action DisplayDefault = async () => await StatusBarMessage(string.Empty, UXNotificationType.DefaultMessage);
                switch (messageType)
                {
                    case UXNotificationType.ErrorMessage:
                        await StatusBarMessage(message, UXNotificationType.ErrorMessage);
                        //DisplayDefault.DelayFor(TimeSpan.FromSeconds(_actionDelay));
                        break;
                    case UXNotificationType.SuccessMessage:
                        await StatusBarMessage(message, UXNotificationType.SuccessMessage);
                        //DisplayDefault.DelayFor(TimeSpan.FromSeconds(_actionDelay));
                        break;
                    case UXNotificationType.OperationMessage:
                        await StatusBarMessage(message, UXNotificationType.OperationMessage);
                        //DisplayDefault.DelayFor(TimeSpan.FromSeconds(_actionDelay));
                        break;
                    case UXNotificationType.DefaultMessage:
                        await StatusBarMessage(message, UXNotificationType.DefaultMessage);
                        //DisplayDefault.DelayFor(TimeSpan.FromSeconds(_actionDelay));
                        break;
                    default:
                        await StatusBarMessage(message, UXNotificationType.OperationMessage);
                        //DisplayDefault.DelayFor(TimeSpan.FromSeconds(_actionDelay));
                        break;
                }
            }
            catch (Exception) { }
        }
        private async Task StatusBarMessage(string message, UXNotificationType messageType)
        {
            await Application.Current.Dispatcher.BeginInvoke(
                       DispatcherPriority.Normal,
                       new Action(
                           delegate ()
                           {
                               UXStatusBarNotification statusMessage = GetStatusBarMessage(message, messageType);
                               _eventAggregator.GetEvent<StatusBarNotificationChangedEvent>().Publish(statusMessage);
                           }
                       )
                   );
        }
        /// <summary>
        /// Display message in the StatusBar of the Application.
        /// </summary>
        /// <param name="message">Message to be displayed</param>
        /// <param name="UXNotificationType">Type of the message.</param>
        /// <returns>UXStatusBarNotification object</returns>
        private UXStatusBarNotification GetStatusBarMessage(string message, UXNotificationType messageType)
        {
            UXStatusBarNotification statusMessage = new UXStatusBarNotification()
            {
                Message = message
            };
            switch (messageType)
            {
                case UXNotificationType.OperationMessage:
                    statusMessage.StatusType = UXNotificationType.OperationMessage;
                    statusMessage.StatusColor = "#D04D03";
                    break;
                case UXNotificationType.DefaultMessage:
                    statusMessage.StatusType = UXNotificationType.DefaultMessage;
                    statusMessage.StatusColor = "Transparent";
                    //statusMessage.StatusColor = "#007ACC";
                    //Transparent
                    break;
                case UXNotificationType.SuccessMessage:
                    statusMessage.StatusType = UXNotificationType.SuccessMessage;
                    statusMessage.StatusColor = "#217346";
                    break;
                case UXNotificationType.ErrorMessage:
                    statusMessage.StatusType = UXNotificationType.ErrorMessage;
                    statusMessage.StatusColor = "#9A0008";
                    statusMessage.Progress = 10; //shahab: increase the timeout to 10 sec for error message.
                    break;
                default:
                    statusMessage.Message = string.Empty;
                    statusMessage.StatusType = UXNotificationType.DefaultMessage;
                    break;
            }
            return statusMessage;
        }
        #endregion
    }
}
