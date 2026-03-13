namespace SalesSystem.Rfq.Components.Pages.Dialogs
{
    public partial class NprRequestEditDialog
    {
        [CascadingParameter]
        public IMudDialogInstance MudDialog 
        { get; set; } = null!;

        [Parameter]
        public RfqNprRequestUxModel NprRequest 
        { get; set; } = new();

        MudForm? _Form;

        bool IsSamplesRequired => NprRequest.SamplesRequired == true;

        void Cancel()
        {
            MudDialog.Cancel();
        }

        void Save()
        {
            DialogResult result = DialogResult.Ok(NprRequest);
            MudDialog.Close(result);
        }
    }
}