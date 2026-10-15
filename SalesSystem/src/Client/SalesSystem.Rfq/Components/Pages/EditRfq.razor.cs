using SalesSystem.Rfq.ViewModels;

namespace SalesSystem.Rfq.Components.Pages
{
    public partial class EditRfq : MvvmComponentBase<EditRfqViewModel>
    {
        Composites? _CompositesRef;
        NprRequestsEditor? _ComponentNprEditor;

        [Parameter] public long RfqProjectId { get; set; }
        [CascadingParameter(Name = "GlobalValue")]
        public GlobalValue? GlobalValue { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            ViewModel.RfqProjectId = RfqProjectId;
            ViewModel.GlobalValue = GlobalValue;
            ViewModel.CompositesRef = _CompositesRef;
            ViewModel.ComponentNprEditor = _ComponentNprEditor;
            await base.OnParametersSetAsync();
        }
    }
}
