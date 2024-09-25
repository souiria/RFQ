using Prism.Interactivity.InteractionRequest;

namespace Common.UX.Wpf.Contracts.Models.Dialog
{
    public class UXConfirmationDialog : UXCustomDialogBase, IConfirmation
    {
        public delegate void CallbackHandler(bool? actionResult);
        public CallbackHandler ActionHandler { get; }
        public bool Confirmed { get; set; }
        public UXConfirmationDialog(CallbackHandler callback)
        {
            ActionHandler = callback;
        }
    }
}
