using SalesSystem.Rfq.ViewModels;

namespace SalesSystem.Rfq.Components.Pages
{
    public partial class RfqDashboard : MvvmComponentBase<RfqDashboardViewModel>
    {
        [CascadingParameter(Name = "GlobalValue")]
        public GlobalValue? GlobalValue { get; set; }

        protected override void OnParametersSet()
        {
            // _vm.UserId = UserId;
            ViewModel.GlobalValue = GlobalValue;
            base.OnParametersSet();
        }
    }
}
