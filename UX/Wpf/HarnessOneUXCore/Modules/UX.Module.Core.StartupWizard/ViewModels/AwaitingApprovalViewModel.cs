using Common.UX.Wpf.Base.Commercial;
using Prism.Events;
using Prism.Regions;

namespace SEWSE.H1.UX.Module.Core.StartupWizard.ViewModels
{
    public class AwaitingApprovalViewModel : BaseViewModel
    {
        #region Properties     

        private string _helpdeskId;
        public string HelpdeskId
        {
            get => _helpdeskId;
            set => SetProperty(ref _helpdeskId, value);
        }

        #endregion

        public AwaitingApprovalViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(eventAggregator, regionManager)
        {
        }

        protected override void NavigatedTo(NavigationContext navigationContext)
        {
            HelpdeskId = (string)navigationContext.Parameters["HelpdeskId"];
        }
    }
}
