using Common.UX.Wpf.Base;
using Common.UX.Wpf.Helpers;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;

namespace SEWSE.H1.UX.Module.Core.StartupWizard.ViewModels
{
    public class WelcomeViewModel : BaseViewModel
    {
        public DelegateCommand PermissionCommand { get; private set; }

        public WelcomeViewModel(IEventAggregator eventAggregator, IRegionManager regionManager) : base(eventAggregator, regionManager)
        {
            PermissionCommand = new DelegateCommand(() => RegionManager.Regions[RegionNames.WizardRegion].RequestNavigate("GroupPermission"));
        }        
    }
}
