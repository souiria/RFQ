using Microsoft.Win32;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Squirrel;
using System.Threading.Tasks;
using System.Windows;
using Common.UX.Wpf.Commands;
using Common.UX.Wpf.Events;
using Common.UX.Wpf.Helpers;
using Common.UX.Logging;

namespace SEWSE.H1.UX.Shell.ViewModels
{
    public class UpdateDialogViewModel : BindableBase
    {
        #region Properties

        //DispatcherTimer _timer;
        //private int _time;
        //private int _postponeAllowance;
        //private int _postponeCount;
        //private bool _isForcedUpdate;
        //private int _timeUntilRestart;

        readonly IEventAggregator _eventAggregator;
        public ApplicationUpdater ApplicationUpdater;

        //private ObservableCollection<PostponeTime> postponeTimes;
        //public PostponeTime SelectedTime { get; set; }
        public AwaitableDelegateCommand UpdateRestartCommand { get; private set; }
        public DelegateCommand UpdatePostponeCommand { get; private set; }
        public AwaitableDelegateCommand UpdateRestartLaterCommand { get; private set; }
        public AwaitableDelegateCommand LoadedCommand { get; private set; }

        private Visibility _dialogWindowVisilibity;
        public Visibility DialogWindowVisilibity
        {
            get { return _dialogWindowVisilibity; }
            set { SetProperty(ref _dialogWindowVisilibity, value); }
        }

        private Visibility _postponeVisibility = Visibility.Visible;
        public Visibility PostponeVisibility
        {
            get { return _postponeVisibility; }
            set { SetProperty(ref _postponeVisibility, value); }
        }

        private Visibility _backgroundVisibility = Visibility.Visible;
        public Visibility BackgroundVisibility
        {
            get { return _backgroundVisibility; }
            set { SetProperty(ref _backgroundVisibility, value); }
        }

        

        private Visibility _progressVisibility;
        public Visibility ProgressVisibility
        {
            get { return _progressVisibility; }
            set { SetProperty(ref _progressVisibility, value); }
        }

        private Visibility _canPostponeText;
        public Visibility CanPostponeText
        {
            get { return _canPostponeText; }
            set { SetProperty(ref _canPostponeText, value); }
        }

        private bool _isButtonEnabled = true;
        public bool IsButtonEnabled
        {
            get { return _isButtonEnabled; }
            set { SetProperty(ref _isButtonEnabled, value); }
        }

        private int _progress;
        public int Progress
        {
            get => _progress;
            set => SetProperty(ref _progress, value);
        }

        private string _topDialogMessage;
        public string TopDialogMessage
        {
            get { return _topDialogMessage; }
            set { SetProperty(ref _topDialogMessage, value); }
        }

        private string _dialogText;
        public string DialogText
        {
            get { return _dialogText; }
            set { SetProperty(ref _dialogText, value); }
        }

        #endregion

        #region Constructor
        public UpdateDialogViewModel(IEventAggregator eventaggregator)
        {
            SystemEvents.SessionSwitch += new SessionSwitchEventHandler(SystemEvents_SessionSwitch);
            _eventAggregator = eventaggregator;
            SetDefaultProperties();

            #region Commands

            UpdateRestartCommand = new AwaitableDelegateCommand(RestartButtonClick);
            UpdatePostponeCommand = new DelegateCommand(PostponeButtonClick);
            UpdateRestartLaterCommand = new AwaitableDelegateCommand(RestartLaterButtonClick);
            LoadedCommand = new AwaitableDelegateCommand(ViewLoad);
            #endregion

            ApplicationUpdater = new ApplicationUpdater(_eventAggregator);
            DialogText = "There is a new version of the application available.\r\nWould you like to install and restart now?";

        }

        #endregion

        #region Methods

        private async Task ViewLoad()
        {
#if DEBUG
            UpdateInfo update = null;
            //var update = await ApplicationUpdater.CheckForUpdate();
#else
            var update = await ApplicationUpdater.CheckForUpdate();
#endif
            //Modified by Vishwadeep Singh on 30-Nov-2022 :: Take Update Automatically when new version is available. Start
            if (update != null)
            {
                if (update.CurrentlyInstalledVersion != null && update.FutureReleaseEntry != null)
                {
                    if (update.CurrentlyInstalledVersion != update.FutureReleaseEntry)
                    {
                        DialogWindowVisilibity = Visibility.Visible;
                        await RestartButtonClick();
                    }
                }
                //Commented by vishwadeep Singh on 02-Dec-2022
                /*if (update.CurrentlyInstalledVersion != null)
                {
                    if (update.FutureReleaseEntry.Version.Version.Major > update.CurrentlyInstalledVersion.Version.Version.Major ||
                        (update.FutureReleaseEntry.Version.Version.Major == update.CurrentlyInstalledVersion.Version.Version.Major &&
                        update.FutureReleaseEntry.Version.Version.Minor > update.CurrentlyInstalledVersion.Version.Version.Minor))
                    {
                        PostponeVisibility = Visibility.Collapsed;
                        CanPostponeText = Visibility.Visible;
                    }
                }*/
            }
            //Modified by Vishwadeep Singh on 30 - Nov - 2022 :: End
        }

        private void SetDefaultProperties()
        {
            ProgressVisibility = Visibility.Collapsed;
            Progress = 0;
            DialogWindowVisilibity = Visibility.Collapsed;
            CanPostponeText = Visibility.Collapsed;
            BackgroundVisibility = Visibility.Collapsed;
        }

        private async Task RestartLaterButtonClick()
        {
            DialogWindowVisilibity = Visibility.Collapsed;
            await ApplicationUpdater.Update();
            //TODO: Bottom right progress update method
            _eventAggregator.GetEvent<UpdateStatusBarMessageEvent>().Publish("Update is ready. Please restart the application");
        }

        //Modified by Vishwadeep On 30-Nov-2022 :: Added log and try catch
        private async Task RestartButtonClick()
        {
            ProgressVisibility = Visibility.Visible;
            CanPostponeText = Visibility.Collapsed;
            IsButtonEnabled = false;
            DialogText = "Please wait while we install the update...";
            UXLogger.UXLoggingForDebug($"UpdateDialogViewModel :: RestartButtonClick:: Update Start");

            try
            {
                await ApplicationUpdater.Update(UpdateProgress);
            }
            catch (System.Exception ex)
            {
                UXLogger.UXLoggingForDebug($"UpdateDialogViewModel :: RestartButtonClick:: Error : Update End\n" + ex.Message + System.Environment.NewLine);
            }

            UXLogger.UXLoggingForDebug($"UpdateDialogViewModel :: RestartButtonClick:: Update End");

            try
            {
                UXLogger.UXLoggingForDebug($"UpdateDialogViewModel :: RestartButtonClick:: Restart Start");
                UpdateManager.RestartApp();
                UXLogger.UXLoggingForDebug($"UpdateDialogViewModel :: RestartButtonClick:: Restart End");
            }
            catch (System.Exception ex)
            {
                UXLogger.UXLoggingForDebug($"UpdateDialogViewModel :: RestartButtonClick:: Restart Error : " + ex.Message);
            }
        }
        private void PostponeButtonClick()
        {
            DialogWindowVisilibity = Visibility.Collapsed;
        }

        private void UpdateProgress(int obj)
        {
            Progress = obj;
        }

        async void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
#if !DEBUG
            switch (e.Reason)
            {
                case SessionSwitchReason.SessionLock:
                    await ApplicationUpdater.CheckForUpdate();
                    break;
                case SessionSwitchReason.SessionUnlock:
                    break;
            }
#endif
        }

        #endregion
    }
}