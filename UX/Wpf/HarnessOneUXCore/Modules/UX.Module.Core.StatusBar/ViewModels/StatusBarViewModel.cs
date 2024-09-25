using Common.UX.Wpf.Contracts.Models;
using Common.UX.Wpf.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Timers;
using System.Windows;
using System.Windows.Threading;

namespace SEWSE.H1.UX.Module.Core.StatusBar.ViewModels
{
    public class StatusBarViewModel : BindableBase
    {
        #region Properties
        private string _statusMessage;
        public string StatusMessage
        {
            get { return _statusMessage; }
            set { SetProperty(ref _statusMessage, value); }
        }
        private ObservableCollection<UXStatusBarNotification> _statusMessageList;
        public ObservableCollection<UXStatusBarNotification> StatusMessageList
        {
            get { return _statusMessageList; }
            set
            {
                SetProperty(ref _statusMessageList, value);
            }
        }
        private string _statusColor;
        public string StatusColor
        {
            get { return _statusColor; }
            set { SetProperty(ref _statusColor, value); }
        }
        private string _colorChanged;
        public string ColorChanged
        {
            get { return _colorChanged; }
            set { SetProperty(ref _colorChanged, value); }
        }
        private string _startColor;
        public string StartColor
        {
            get { return _startColor; }
            set { SetProperty(ref _startColor, value); }
        }
        private Visibility _enableButton;
        public Visibility EnableButton
        {
            get { return _enableButton; }
            set { SetProperty(ref _enableButton, value); }
        }
        private Visibility _enableList;
        public Visibility EnableList
        {
            get { return _enableList; }
            set { SetProperty(ref _enableList, value); }
        }
        private bool _showList;
        public bool ShowList
        {
            get { return _showList; }
            set { SetProperty(ref _showList, value); }
        }
        private IEventAggregator _eventAggregator;
        private IEventAggregator eventAggregator
        {
            get { return _eventAggregator; }
            set { SetProperty(ref _eventAggregator, value); }
        }
        public DelegateCommand ShowClickCommand { get; set; }
        public DelegateCommand CloseClickCommand { get; set; }
        public DelegateCommand<String> RemoveItemCommand { get; set; }

        private List<UXStatusBarNotification> ExpiryList;

        private static System.Timers.Timer AnimationTimer;
        private static System.Timers.Timer ExpiryTimer;

        private bool StartNew;
        private bool Running;
        #endregion

        private string _updateMessage;

        private int _longest;
        public int Longest
        {
            get { return _longest; }
            set { SetProperty(ref _longest, value); }
        }

        private readonly string RefreshMessage = "/Refresh";

        public StatusBarViewModel(IEventAggregator ea)
        {
            ShowClickCommand = new DelegateCommand(Show);
            CloseClickCommand = new DelegateCommand(Close);
            RemoveItemCommand = new DelegateCommand<String>(RemoveItem);
            EnableButton = Visibility.Hidden;
            EnableList = Visibility.Hidden;
            StatusMessageList = new ObservableCollection<UXStatusBarNotification>();
            ExpiryList = new List<UXStatusBarNotification>();
            eventAggregator = ea;
            StartNew = false;
            Longest = 100;

            AnimationTimer = new System.Timers.Timer(1000);
            AnimationTimer.Elapsed += ColourTimedEvent;
            AnimationTimer.AutoReset = false;
            AnimationTimer.Enabled = true;

            ExpiryTimer = new System.Timers.Timer(100);
            ExpiryTimer.Elapsed += ExpiryCheck;
            ExpiryTimer.AutoReset = true;
            ExpiryTimer.Enabled = true;
            ExpiryTimer.Start();

            eventAggregator.GetEvent<MaximizeScreenEvent>().Subscribe(MaximizeScreen);
            eventAggregator.GetEvent<UpdateStatusBarMessageEvent>().Subscribe(UpdateStatusReceived);
            eventAggregator.GetEvent<StatusBarNotificationChangedEvent>().Subscribe(StatusMessageChanged);
            eventAggregator.GetEvent<MessageUpdateEvent>().Publish(new MessageUpdateEvent { Message = "Loading StatusBar Module" });
        }

        private void StatusMessageChanged(UXStatusBarNotification message)
        {
            try
            {
                //Check if new message is interupting any running animations
                if (Running)
                {
                    StartNew = true;
                    if (AnimationTimer != null)
                        AnimationTimer.Stop();
                }

                #region If Reset
                //Check for reset message
                if (message.StatusType == UXNotificationType.DefaultMessage || message.Message == string.Empty)
                {
                    if (StatusMessageList.Count > 0)
                    {
                        StatusMessageList.Clear();
                    }
                    EnableButton = Visibility.Hidden;
                    EnableList = Visibility.Hidden;
                    ShowList = false;
                    StartColor = "Transparent";
                    ColorChanged = "Transparent";
                    while (ExpiryList.Count > 0)
                    {
                        ExpiryList[0].Progress = 0;
                        ExpiryList.RemoveAt(0);
                    }
                }
                #endregion
                else
                {
                    StartNew = false;

                    #region Refresh Message
                    if (message.Message == RefreshMessage)
                    {
                        switch (StatusMessageList.Count)
                        {
                            case 0:
                                EnableButton = Visibility.Hidden;
                                EnableList = Visibility.Hidden;
                                StatusMessage = string.Empty;
                                ShowList = false;
                                StartColor = "Transparent";
                                ColorChanged = "Transparent";
                                break;
                            default:
                                for (int i = 0; i < StatusMessageList.Count;)
                                {
                                    if (StatusMessageList[i] != null && !ExpiryList.Contains(StatusMessageList[i]))
                                    {
                                        EnableButton = Visibility.Visible;
                                        StatusMessage = StatusMessageList[i].Message;
                                        message = StatusMessageList[i];
                                        switch (StatusMessageList[i].StatusColor)
                                        {
                                            case "#9A0008":
                                                message.StatusType = UXNotificationType.ErrorMessage;
                                                break;
                                            case "#D04D03":
                                                message.StatusType = UXNotificationType.OperationMessage;
                                                break;
                                            case "#217346":
                                                message.StatusType = UXNotificationType.SuccessMessage;
                                                break;
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        i++;
                                    }
                                }
                                break;

                        }
                    }
                    #endregion
                    else
                    {
                        ShowList = false;
                        EnableButton = Visibility.Visible;

                        #region Prevent duplicate entries
                        bool found = false;
                        foreach (UXStatusBarNotification ux in StatusMessageList)
                        {
                            if (ux.Message == message.Message && ux.StatusColor == message.StatusColor)
                            {
                                found = true;
                                ux.Progress = 5;
                                break;
                            }
                        }
                        if (!found)
                        {
                            StatusMessageList.Add(message);
                            Longest = GetLongest();
                        }
                        #endregion
                    }

                    if (StatusMessageList.Count > 1)
                    {
                        if (message.Message != RefreshMessage)
                            StatusMessage = message.Message;
                        if (StatusMessageList.Any(x => x.StatusColor == "#9A0008")) //If one is an error
                            StatusColor = "#9A0008"; //Make the whole message the same color
                        else if (StatusMessageList.Any(x => x.StatusColor == "#D04D03")) //If one is an operational message
                            StatusColor = "#9A0008"; //Make the whole message the same color
                        else
                            StatusColor = "#217346"; //Otherwise make the bar green (success).

                        EnableList = Visibility.Visible;
                        //StatusColor = message.StatusColor;
                        //Red
                        //StatusColor = "#9A0008";
                        //message.StatusType = UXNotificationType.ErrorMessage;
                        //Orange 
                        //StatusColor = "#D04D03";
                        //message.StatusType = UXNotificationType.OperationMessage;
                    }
                    else if (StatusMessageList.Count == 1 && message.Message != RefreshMessage)
                    {
                        StatusMessage = message.Message;
                        StatusColor = message.StatusColor;
                        EnableList = Visibility.Hidden;
                    }
                    else
                    {
                        StatusMessage = string.Empty;
                        StatusColor = "Transparent";
                        EnableList = Visibility.Hidden;
                        EnableButton = Visibility.Hidden;
                    }
                    //SetStatus(message.StatusType);
                    ColorChanged = "None";
                    Running = false;
                }
            }
            catch
            {
                StatusMessage = string.Empty;
                StatusColor = "Transparent";
            }
        }

        private void ExpiryCheck(Object source, ElapsedEventArgs e)
        {
            if (StatusMessageList.Count == 0 && StatusColor != "Transparent" && EnableList == Visibility.Visible)
                StatusMessageChanged(new UXStatusBarNotification { Message = string.Empty, StatusType = UXNotificationType.DefaultMessage, StatusColor = "Transparent" });
            else
            {
                for (int i = 0; i < StatusMessageList.Count;)
                {
                    if (StatusMessageList[i].Progress == 0 && StatusMessageList.Count > 0)
                    {
                        ExpiryList.Add(StatusMessageList[i]);
                    }
                    i++;
                }
                for (int i = 0; i < ExpiryList.Count;)
                {
                    try
                    {
                        if (ExpiryList[i] != null && ExpiryList[i].Progress == 0)
                        {
                            ShowList = false;
                            RemoveItem(StatusMessageList[i].Message);
                            ExpiryList.RemoveAt(i);
                        }
                    }
                    catch
                    {

                    }
                    i++;
                }
            }
        }

        private void SetStatus(UXNotificationType type) //Currently Disabled
        {
            try
            {
                //Set animation and run
                while (!StartNew)
                {
                    Running = true;
                    ColorChanged = "None";

                    //Set the animation start colour
                    StartColor = "";
                    ColorChanged = "None";

                    if (StatusMessageList.Count <= 1)
                    {
                        switch (type)
                        {
                            case UXNotificationType.ErrorMessage:
                                StartColor = "#FF0008";
                                ColorChanged = "Red";
                                break;
                            case UXNotificationType.OperationMessage:
                                StartColor = "#FF6403";
                                ColorChanged = "Orange";
                                break;
                            case UXNotificationType.SuccessMessage:
                                StartColor = "#33AF69";
                                ColorChanged = "Green";
                                break;
                        }
                    }
                    else
                    {
                        StartColor = "#FF0008";
                        ColorChanged = "Red";
                    }
                    //Wait until animation finishes before resuming
                    if (AnimationTimer != null)
                        AnimationTimer.Start();
                    return;
                }
                return;
            }
            catch
            {
                Running = false;
                ColorChanged = "None";
            }
        }

        private void MaximizeScreen(bool isMinimized)
        {
            IsMinimized = Convert.ToBoolean(isMinimized);
        }

        private void UpdateStatusReceived(string updateMessage)
        {
            UpdateStatus = updateMessage;
        }

        private bool _isMinimized;
        public bool IsMinimized
        {
            get => _isMinimized;
            set => SetProperty(ref _isMinimized, value);
        }

        public string UpdateStatus
        {
            get => _updateMessage;
            set => SetProperty(ref _updateMessage, value);
        }

        #region Timer

        private void ColourTimedEvent(Object source, ElapsedEventArgs e)
        {
            //Only reset if there are no other incoming animations
            if (!StartNew && Running)
            {
                ColorChanged = null;
            }
        }
        #endregion

        private int GetLongest()
        {
            int length = 0;

            for (int i = 0; i < StatusMessageList.Count;)// UXStatusBarNotification ux in StatusMessageList)
            {
                if (StatusMessageList[i].Message.Length > length)
                {
                    length = StatusMessageList[i].Message.Length;
                }
                i++;
            }
            return ((length * 5) + 30);
        }

        private void Show()
        {
            ShowList = !ShowList;
        }

        private void RemoveItem(String message)
        {
            foreach (UXStatusBarNotification ux in StatusMessageList)
            {
                if (ux.Message == message)
                {
                    Application.Current.Dispatcher.BeginInvoke(
                    DispatcherPriority.Background,
                        new Action(() =>
                        {
                            StatusMessageList.Remove(ux);
                        }));
                    break;
                }
            }
            Longest = GetLongest();
            StatusMessageChanged(new UXStatusBarNotification { Message = RefreshMessage, StatusType = UXNotificationType.OperationMessage, StatusColor = "Transparent" });
        }

        private void Close()
        {
            RemoveItem(StatusMessage);
        }
    }
}