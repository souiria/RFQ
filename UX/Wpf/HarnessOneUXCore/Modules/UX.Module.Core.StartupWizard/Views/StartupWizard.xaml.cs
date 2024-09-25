using Microsoft.Practices.ServiceLocation;
using Prism.Regions;

namespace SEWSE.H1.UX.Module.Core.StartupWizard.Views
{
    /// <summary>
    /// Interaction logic for StartupWizard.xaml
    /// </summary>
    public partial class StartupWizard 
    {
        public StartupWizard()
        {
            InitializeComponent();
            RegionManager.SetRegionManager(this, ServiceLocator.Current.GetInstance<IRegionManager>());
        }
    }
}
