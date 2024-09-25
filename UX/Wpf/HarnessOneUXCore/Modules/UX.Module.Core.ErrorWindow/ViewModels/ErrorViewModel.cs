using Prism.Commands;
using Prism.Modularity;
using Squirrel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Common.UX.Wpf.Base;
using Common.UX.Wpf.Commands;
using Common.UX.Wpf.Helpers;

namespace SEWSE.H1.UX.Module.Core.ErrorWindow.ViewModels
{
    public class ErrorViewModel : ViewModelBase
    {

        private RoleBasedModuleInitializer _moduleInitializer;

        private string _exceptionText;
        public string ExceptionText
        {
            get => _exceptionText;
            set => SetProperty(ref _exceptionText, value);
        }

        private Visibility _rollbackMenuVisibility;
        public Visibility RollbackMenuVisibility
        {
            get => _rollbackMenuVisibility;
            set => SetProperty(ref _rollbackMenuVisibility, value);
        }

        private ObservableCollection<ReleaseEntry> _releaseVersions;
        public ObservableCollection<ReleaseEntry> ReleaseVersions
        {
            get => _releaseVersions;
            set => SetProperty(ref _releaseVersions, value);
        }

        private ReleaseEntry _selectedVersion;
        public ReleaseEntry SelectedVersion
        {
            get => _selectedVersion;
            set => SetProperty(ref _selectedVersion, value);
        }

        private bool _isWindowEnabled;
        public bool IsWindowEnabled
        {
            get => _isWindowEnabled;
            set => SetProperty(ref _isWindowEnabled, value);
        }

        private string _currentVersion;
        public string CurrentVersion
        {
            get => _currentVersion;
            set => SetProperty(ref _currentVersion, value);
        }


        public DelegateCommand RollbackCancelCommand { get; set; }
        public DelegateCommand RollbackOkCommand { get; set; }
        public DelegateCommand OpenRollbackMenuCommand { get; set; }
        public AwaitableDelegateCommand PageLoadedCommand { get; set; }

        public ErrorViewModel(IModuleInitializer moduleInitializer)
        {
            _moduleInitializer = (RoleBasedModuleInitializer)moduleInitializer;
            var exception = _moduleInitializer.exceptionThrown;
            RollbackMenuVisibility = Visibility.Collapsed;
            IsWindowEnabled = true;

            OpenRollbackMenuCommand = new DelegateCommand(() => { RollbackMenuVisibility = Visibility.Visible; IsWindowEnabled = false; });
            RollbackCancelCommand = new DelegateCommand(() => { RollbackMenuVisibility = Visibility.Collapsed; IsWindowEnabled = true; });
            RollbackOkCommand = new DelegateCommand(RollbackVersion);
            PageLoadedCommand = new AwaitableDelegateCommand(ExecuteViewLoad);
            ExceptionText = "";
            do
            {
                ExceptionText += exception.Message;

            } while ((exception = exception.InnerException) != null);
        }

        private async Task ExecuteViewLoad()
        {
            try
            {
                ReleaseVersions =
                    new ObservableCollection<ReleaseEntry>(ApplicationUpdater.ReadVersions().Where(x => !x.IsDelta));
            }
            catch
            {
                //ignore
            }
            // CurrentVersion = await ApplicationUpdater.GetCurrentVersion();
        }

        private void RollbackVersion()
        {
            //if (SelectedVersion != null)
            //{
            //    var versions = ReleaseVersions.Where(x => x.Version <= SelectedVersion.Version);                
            //    ApplicationUpdater.InstallVersion(versions);
            //}
        }
    }
}
