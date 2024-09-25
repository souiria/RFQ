using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Media.Imaging;
using Common.UX.Api.Commercial;
using Common.UX.Api.Endpoints;
using Common.UX.Wpf.Base;
using Common.UX.Wpf.Contracts.Models;
using Common.UX.Wpf.Events;
using Common.UX.Wpf.Helpers;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Prism.Regions;

namespace SEWSE.H1.UX.Module.Core.RibbonTabs.ViewModels
{
    public class HomeTabViewModel : ViewModelBase
    {
        #region Properties
        private NotificationHelper notificationHelper;
        public DelegateCommand TestNotificationClickCommand { get; set; }
        public DelegateCommand OpenNotificationsCommand { get; set; }
        public DelegateCommand OpenUserManualCommand { get; set; }
        public DelegateCommand MaxMinButtonClickCommand { get; set; }

        private bool _online;
        public bool Online
        {
            get => _online;
            set => SetProperty(ref _online, value);
        }

        #region Labels
        private bool _isUAT;
        public bool IsUAT
        {
            get => _isUAT;
            set => SetProperty(ref _isUAT, value);
        }


        #region Labels

        private string _homeLabel;
        public string HomeLabel
        {
            get => _homeLabel;
            set => SetProperty(ref _homeLabel, value);
        }

        private string _notificationLabel;
        public string NotificationLabel
        {
            get => _notificationLabel;
            set => SetProperty(ref _notificationLabel, value);
        }

        private string _h1UserManualLabel;
        public string H1UserManualLabel
        {
            get => _h1UserManualLabel;
            set => SetProperty(ref _h1UserManualLabel, value);
        }

        #endregion

        private string _notifications;
        public string Notifications
        {
            get => _notifications;
            set
            {
                if (value != "0")
                    SetProperty(ref _notifications, value);
                else
                    SetProperty(ref _notifications, null);
            }
        }

        private bool _maximized = false;

        private string _maxMinButtonTooltip;
        public string MaxMinButtonTooltip
        {
            get => _maxMinButtonTooltip;
            set => SetProperty(ref _maxMinButtonTooltip, value);
        }

        private BitmapImage _maxMinButtonImage;
        public BitmapImage MaxMinButtonImage
        {
            get => _maxMinButtonImage;
            set => SetProperty(ref _maxMinButtonImage, value);
        }

        #endregion

        #endregion

        public HomeTabViewModel(IEventAggregator eventAggregator, IRegionManager regionManager, IUnityContainer container) : base(eventAggregator)
        {
            _regionManager = regionManager;
            notificationHelper = container.Resolve<NotificationHelper>();
            notificationHelper.NotificationConnectionChanged += NotificationHelper_NotificationConnectionChanged;
            Online = notificationHelper.Online;
            TestNotificationClickCommand = new DelegateCommand(() => { ShowBusyIndicator(PublishTestNotification); });
            OpenNotificationsCommand = new DelegateCommand(OpenNotifications);
            MaxMinButtonClickCommand = new DelegateCommand(MaximizeScreen);
            OpenUserManualCommand = new DelegateCommand(OpenUserManual);

            _eventAggregator.GetEvent<ModuleLoadedEvent>().Publish(new ModuleLoadedEvent { Message = "Loading RibbonTabs Module" });
            //Disabled until UX notifications has been reworked.

            //_eventAggregator.GetEvent<StandardNotificationEvent>().Subscribe(UpdateNotifications);
            //_eventAggregator.GetEvent<UpdateNotificationCountEvent>().Subscribe(() => UpdateNotifications(null));

            _maxMinButtonTooltip = "Maximize Layout";
            _maxMinButtonImage = new BitmapImage(new Uri("pack://application:,,,/Common.UX;component/Resources/Images/MaximizeLayout16.png"));

            AddLabels();


#if !UAT
            IsUAT = false;
#else
        IsUAT = true;
#endif

        }

        private void OpenUserManual()
        {
            try
            {
                string FilePath;
                FilePath = Environment.CurrentDirectory + "\\UserManual\\HarnessOne-UserManual.docx";
                if (FilePath != null || FilePath != string.Empty)
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo(FilePath);
                    Process.Start(startInfo);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void NotificationHelper_NotificationConnectionChanged(object sender, bool connected)
        {
            Online = connected;
        }

        private void AddLabels()
        {
            LabelsNeeded.Add("00003");
            LabelsNeeded.Add("00005");
        }

        private void MaximizeScreen()
        {
            _maximized = !_maximized;
            if (_maximized)
            {
                MaxMinButtonTooltip = "Minimize Layout";
                MaxMinButtonImage = new BitmapImage(new Uri("pack://application:,,,/Common.UX;component/Resources/Images/MinimizeLayout16.png"));
            }
            else
            {
                MaxMinButtonTooltip = "Maximize Layout";
                MaxMinButtonImage = new BitmapImage(new Uri("pack://application:,,,/Common.UX;component/Resources/Images/MaximizeLayout16.png"));
            }
            _eventAggregator.GetEvent<MaximizeScreenEvent>().Publish(_maximized);
        }

        public override void PageLoaded()
        {
            base.PageLoaded();
            FillLabels();
            //UpdateNotifications(null);
        }

        private void FillLabels()
        {
            HomeLabel = Labels["00003"] ?? "Home";
            NotificationLabel = Labels["00005"] ?? "Notifications";
            H1UserManualLabel = Labels["50449"] ?? "H1 User Manual";

        }

        private void UpdateNotifications(object obj)
        {
            try
            {
                Notifications = ServiceHelper.Base64Get<IEnumerable<Notification>>(ServiceEndpointRoutes.UserNotifications, UserPreferenceSetupHelper.UserPrincipalGuid.ToString(), false).Count().ToString();
            }
            catch (Exception ex)
            {
                Notifications = null;
                string error = $"{ex.Message}. {Environment.NewLine} {(ex.InnerException == null ? string.Empty : ex.InnerException.Message)}";
                _statusMessage.DisplayMessage(error, "UpdateNotifications::ViewModel", UXNotificationType.ErrorMessage);
            };
        }

        private void PublishTestNotification()
        {

            //var notificationitem = new Notification { Id = Guid.NewGuid(), MessageHeader = "Notification Header", MessageBody = "This is a test notification", IsRead = false, NotifyDate = DateTime.Now, Origin = "Country" };
            //NotificationHelper.Publish("GlobalMasterServiceChannel", notificationitem);
        }

        private void OpenNotifications()
        {
            var parameters = new NavigationParameters();
            parameters.Add("View", "00005");
            parameters.Add("Module", "00005");
            parameters.Add("Function", UserPreferenceSetupHelper.CurrentUser.Username);
            _regionManager.RequestNavigate(RegionNames.ContentRegion, "Notifications", parameters);
        }
    }
}
