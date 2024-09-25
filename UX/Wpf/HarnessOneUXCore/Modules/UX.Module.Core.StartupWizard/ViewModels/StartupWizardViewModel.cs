using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System.Threading.Tasks;
using System.Windows;
using Common.Core.Contracts.Models.Administration.Security;
using Common.UX.Wpf.Base.Commercial;
using Common.UX.Wpf.Helpers;

namespace SEWSE.H1.UX.Module.Core.StartupWizard.ViewModels
{
    public class StartupWizardViewModel : BaseViewModel
    {
        public DelegateCommand CloseCommand { get; private set; }

        public StartupWizardViewModel(IEventAggregator eventAggregator, IRegionManager regionManager) : base(eventAggregator, regionManager)
        {
            CloseCommand = new DelegateCommand(Close);
        }

        protected override async Task ExecuteViewLoad()
        {
            //Create view based on user launch status
            if (await StartupHelper.GetLaunchStatusTask == LaunchStatus.Requested)
                Navigate("AwaitingApproval");
            else
                Navigate("Welcome");
        }

        private static void Close()
        {
            Application.Current.MainWindow.Close();
        }

        private void Navigate(string page)
        {
            RegionManager.Regions[RegionNames.WizardRegion].RequestNavigate(page);
        }
    }
}
