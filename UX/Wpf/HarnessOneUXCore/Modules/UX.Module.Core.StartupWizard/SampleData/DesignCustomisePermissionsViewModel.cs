using Prism.Events;
using Prism.Regions;
using SEWSE.H1.UX.Module.Core.StartupWizard.ViewModels;

namespace SEWSE.H1.UX.Module.Core.StartupWizard.SampleData
{
    public class DesignCustomisePermissionsViewModel : CustomisePermissionsViewModel
    {
        public DesignCustomisePermissionsViewModel(IEventAggregator eventAggregator, IRegionManager regionManager) : base(eventAggregator, regionManager)
        {
            //Hierarchy = new ObservableCollection<FunctionHierarchyModel>
            //{
            //    new FunctionHierarchyModel
            //    {
            //        FunctionName = "GlobalMasters",
            //        Modules = 


            //    }
            //}
        }
    }
}
