using SalesSystem.Rfq.ViewModels;

namespace SalesSystem.Rfq.Components.Pages
{
    public partial class CreateRfq : MvvmComponentBase<CreateRfqViewModel>
    {
        // Reference to the FileManager component
        FileManager? _ComponentFileManager;
        FileCards? _ComponentFileCards;

        [CascadingParameter(Name = "GlobalValue")]
        public GlobalValue? GlobalValue { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            ViewModel.GlobalValue = GlobalValue;
            ViewModel.ResetInputFileRequested ??= ResetInputFileAsync;
            await base.OnParametersSetAsync();
        }

        async Task ResetInputFileAsync()
        {
            if (_ComponentFileManager != null)
            {
                await _ComponentFileManager.ResetInputFileAsync();
            }
        }
    }
}