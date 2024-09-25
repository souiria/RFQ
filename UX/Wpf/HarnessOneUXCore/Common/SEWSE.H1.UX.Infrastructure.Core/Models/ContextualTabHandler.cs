using Infragistics.Windows.Ribbon;

namespace SEWSE.H1.UX.Infrastructure.Core.Models
{
    public class ContextualTabHandler
    {
        public RibbonTabItem SelectedTabItem { get; set; }
        public ContextualTabGroup SelectedTabGroup { get; set; }
        public bool IsOpening { get; set; }
    }
}