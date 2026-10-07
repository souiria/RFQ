using SalesSystem.Rfq.ViewModels;

namespace SalesSystem.Rfq.Components.Pages
{
    public partial class ListRfqs : MvvmComponentBase<ListRfqsViewModel>
    {
        [CascadingParameter(Name = "GlobalValue")]
        public GlobalValue? GlobalValue { get; set; }

        protected override void OnParametersSet()
        {
            ViewModel.GlobalValue = GlobalValue;
            base.OnParametersSet();
        }
    }
}