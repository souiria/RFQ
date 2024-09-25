namespace Common.UX.Wpf.Contracts.Models.Dialog
{
    public class UXCustomDialogBase
    {
        public string Title { get; set; }
        public object Content { get; set; }
        public UXDialogTypes Type { get; set; }
    }
}
