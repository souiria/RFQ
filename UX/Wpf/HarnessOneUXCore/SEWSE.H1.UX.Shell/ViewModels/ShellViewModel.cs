/**************************************************************************************************
(C) 2020 SEWS-E Ltd., All rights reserved
File Name          :   ShellViewModel.cs
Function           :   Maintain Details of Shell
Created By         :   Yati
Created on         :   07-Jan-2020
Revision History   :   [07-Jan-2020] : Yati
*                  :   [ ] : Added progress ring loader
*                  :   [08-Jan-2020] : Yati
*                  :   [ ] : Added Percentage in spinner  
*                  :   [09-Jan-2020] : Yati
*                  :   [ ] : Loader added showing progress after upload
*                  :   [02-Apr-2020] : Amit
*                  :   [ ] : Add Logging w.r.t GZip Issue
*                  :   [28-Dec-2021] : Shivam Kalia
*                  :   [ ] : Added OkConfirmation in ShowDialog function
****************************************************************************************************/
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System.Collections.Generic;
using System.Timers;
using System.Windows.Input;
using Common.Core.Contracts.Models.Administration.Security;
using Common.UX.Wpf.Base;
using Common.UX.Wpf.Contracts.Models;
using Common.UX.Wpf.Contracts.Models.Dialog;
using Common.UX.Wpf.Events;
using Prism.Interactivity.InteractionRequest;
using Notification = Common.Core.Contracts.Models.Core.Notifications.Notification;
using Common.UX.Logging;
using Common.UX.Helpers;
using Common.UX.Wpf.Helpers;

namespace SEWSE.H1.UX.Shell.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        public InteractionRequest<UXConfirmationDialog> CustomConfirmationNotificationRequest { get; private set; }
        public InteractionRequest<INotification> CustomErrorNotificationRequest { get; private set; }
        private readonly IRegionManager _manager;
        private readonly Timer busyIndicatorTimeout;

        //Dummy Data has been added to initialize the infragistics dlls before the applicaiton has properly shown itself. This reduces pausing when opening views that have infragistics controls on them.
        public List<Notification> DummyData
        {
            get => new List<Notification> { new Notification { Body = "DummyData" } };
        }

        public ICommand BusyIndicatorCloseCommand            //Added by Pawan on [22-Nov-2017]
        {
            get;
            private set;
        }

        private LoadingSettings _loadingSettings;
        public LoadingSettings LoadingSettings
        {
            get => _loadingSettings;
            set => SetProperty(ref _loadingSettings, value);
        }

        private UploadingSettings _uploadingSettings;
        public UploadingSettings UploadingSettings
        {
            get => _uploadingSettings;
            set => SetProperty(ref _uploadingSettings, value);
        }

        private bool _isMinimized;
        public bool IsMinimized
        {
            get => _isMinimized;
            set => SetProperty(ref _isMinimized, value);
        }

        private string _appTitle;
        public string AppTitle
        {
            get => _appTitle;
            set => SetProperty(ref _appTitle, value);
        }

        private List<ViewSecurityModel> _exampleList;
        public List<ViewSecurityModel> ExampleList
        {
            get => _exampleList;
            set => SetProperty(ref _exampleList, value);
        }

        private string _busyButtonVisible;
        public string BusyButtonVisible
        {
            get => _busyButtonVisible;
            set => SetProperty(ref _busyButtonVisible, value);
        }

        private string _busyContentCaption;
        public string BusyContentCaption
        {
            get => _busyContentCaption;
            set => SetProperty(ref _busyContentCaption, value);
        }

        public ShellViewModel(IEventAggregator eventAggregator, IRegionManager manager) : base(eventAggregator)
        {
            UXLogger.UXLoggingForDebug($"ShellViewModel :: Constructor :: started");
            _manager = manager;
            busyIndicatorTimeout = new Timer(30000);
            BusyIndicatorCloseCommand = new DelegateCommand(() => DefaultLoader(false));
            _eventAggregator.GetEvent<LoadingEvent>().Subscribe(DefaultLoader);
            _eventAggregator.GetEvent<UploadingEvent>().Subscribe(DefaultUploader);
            _eventAggregator.GetEvent<DownloadingEvent>().Subscribe(DefaultDownloader);
            _eventAggregator.GetEvent<SynchronizingEvent>().Subscribe(DefaultSynchronizer);
            _eventAggregator.GetEvent<ProgressEvent>().Subscribe(ProgressLoader);
            _eventAggregator.GetEvent<LoadingUsingProgressEvent>().Subscribe(LoadingProgressLoader);
            _eventAggregator.GetEvent<LoadingEvent<LoadingSettings>>().Subscribe(ManageLoadingSettings);
            _eventAggregator.GetEvent<MaximizeScreenEvent>().Subscribe(MaximizeScreen);

            //Added by Sharad on [04-Jan-2018]
            CustomConfirmationNotificationRequest = new InteractionRequest<UXConfirmationDialog>();
            CustomErrorNotificationRequest = new InteractionRequest<INotification>();
            eventAggregator.GetEvent<ShellDialogEvent<UXCustomDialogBase>>().Subscribe(ShowDialog);

            AddAdditionalLabels();
        }

        private void DefaultLoader(bool isBusy)
        {
            UXLogger.UXLoggingForDebug($"ShellViewModel :: DefaultLoader :: started");
            UXLogger.UXLoggingForDebug($"ShellViewModel :: DefaultLoader :: Connection EndPoint: { EndpointHelper.EndpointAddress } ");
            UXLogger.UXLoggingForDebug($"ShellViewModel :: DefaultLoader :: Release Update path: { ApplicationUpdater.GetCurrentPath() } ");
            BusyButtonVisible = "Visible";
            BusyContentCaption = "This process is taking longer than expected...";
            LoadingSettings = new LoadingSettings
            {
                IsBusy = isBusy,
                Progress = 0D,
                LoadingText = "Loading...",
                IsIndeterminate = true,
            };
        }

        private void ProgressLoader(int Progress)
        {
            UXLogger.UXLoggingForDebug($"ShellViewModel :: ProgressLoader :: started");
            BusyButtonVisible = "Visible";
            BusyContentCaption = "This process is taking longer than expected...";
            if (Progress == 100)
            {
                LoadingSettings = new LoadingSettings
                {
                    IsBusy = false,
                };
                return;
            }
            LoadingSettings = new LoadingSettings
            {
                IsBusy = true,
                Progress = (double)Progress / 100,
                LoadingText = "Uploading...",
                IsIndeterminate = false,
            };

        }


        private void LoadingProgressLoader(int Progress)
        {
            UXLogger.UXLoggingForDebug($"ShellViewModel :: LoadingProgressLoader :: started");
            BusyButtonVisible = "Visible";
            BusyContentCaption = "This process is taking longer than expected...";
            if (Progress == 100)
            {
                LoadingSettings = new LoadingSettings
                {
                    IsBusy = false,
                };
                return;
            }
            LoadingSettings = new LoadingSettings
            {
                IsBusy = true,
                Progress = (double)Progress / 100,
                LoadingText = "Loading...",
                IsIndeterminate = false,
            };

        }
        private void DefaultDownloader(bool isBusy)
        {
            UXLogger.UXLoggingForDebug($"ShellViewModel :: DefaultDownloader :: started");
            BusyButtonVisible = "Visible";
            BusyContentCaption = "This process is taking longer than expected...";
            LoadingSettings = new LoadingSettings
            {
                IsBusy = isBusy,
                Progress = 0D,
                LoadingText = "Downloading...",
                IsIndeterminate = true
            };
        }

        private void DefaultUploader(bool isBusy)
        {
            UXLogger.UXLoggingForDebug($"ShellViewModel :: DefaultUploader :: started");
            BusyButtonVisible = "Hidden";
            BusyContentCaption = "This process may take time...";
            LoadingSettings = new LoadingSettings
            {
                IsBusy = isBusy,
                Progress = 0D,
                LoadingText = "Uploading...",
                IsIndeterminate = true
            };
            //UploadingSettings = new UploadingSettings
            //{
            //    IsBusy = isBusy,
            //    Progress = 0D,
            //    LoadingText = "Uploading...",
            //    IsIndeterminate = true
            //};
        }

        private void DefaultSynchronizer(bool isBusy)
        {
            UXLogger.UXLoggingForDebug($"ShellViewModel :: DefaultSynchronizer :: started");
            BusyButtonVisible = "Hidden";
            BusyContentCaption = "This process may take time...";
            LoadingSettings = new LoadingSettings
            {
                IsBusy = isBusy,
                Progress = 0D,
                LoadingText = "Synchronizing...",
                IsIndeterminate = true
            };
        }

        private void ManageLoadingSettings(LoadingSettings obj)
        {
            LoadingSettings = obj;
        }

        private void AddAdditionalLabels()
        {
            LabelsNeeded.Add("00001");
        }

        private void MaximizeScreen(bool minimize)
        {
            IsMinimized = minimize;
        }

        public override void PageLoaded()
        {
            UXLogger.UXLoggingForDebug($"ShellViewModel :: PageLoaded :: started");
            base.PageLoaded();
            AppTitle = Labels["00001"] ?? "SEWS-E Harness One";
            UXLogger.UXLoggingForDebug($"ShellViewModel :: PageLoaded :: ended");
        }

        //Added by Sharad on [04-Jan-2018]
        #region Custom Dialog
        private void ShowDialog(UXCustomDialogBase dialogObj)
        {
            switch (dialogObj.Type)
            {
                case UXDialogTypes.Error:
                    RaiseError((UXErrorDialog)dialogObj);
                    break;
                case UXDialogTypes.OkConfirmation:
                case UXDialogTypes.YesNoConfirmation:
                case UXDialogTypes.YesNoCancelConfirmation:
                    RaiseConfirmation((UXConfirmationDialog)dialogObj);
                    break;
                default:
                    break;
            }
        }

        private void RaiseError(UXErrorDialog dialog)
        {
            CustomErrorNotificationRequest.Raise(new Prism.Interactivity.InteractionRequest.Notification { Title = dialog.Title, Content = dialog.Content }, r =>
            { });
        }
        private void RaiseConfirmation(UXConfirmationDialog dialog)
        {
            CustomConfirmationNotificationRequest.Raise(dialog, r =>
            {
                if (r.Confirmed)
                {
                    dialog.ActionHandler(true);
                }
                else
                {
                    if (r.Title == "Closed")
                    {
                        dialog.ActionHandler(null);//this mean user has canclled the Confirmation window!
                    }
                    else
                    {
                        dialog.ActionHandler(false);
                    }
                }
            });
        }
        #endregion
    }
}
