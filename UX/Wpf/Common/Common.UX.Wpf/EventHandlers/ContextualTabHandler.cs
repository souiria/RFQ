using Infragistics.Windows.Ribbon;

namespace Common.UX.Wpf.EventHandlers
{
    public class ContextualTabHandler
    {
        public RibbonTabItem SelectedTabItem { get; set; }
        public ContextualTabGroup SelectedTabGroup { get; set; }
        public bool IsOpening { get; set; }
    }
}