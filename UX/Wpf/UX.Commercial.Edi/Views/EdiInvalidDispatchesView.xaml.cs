using Common.UX.Wpf.Attributes;
using UX.Commercial.Edi.RibbonTabs.Views;

namespace UX.Commercial.Edi.Views
{
    /// <summary>
    /// Interaction logic for EdiInvalidDispatchesView.xaml
    /// </summary>
    [RibbonTab(typeof(InvalidDispatchesTab))]
    public partial class EdiInvalidDispatchesView
    {
        public EdiInvalidDispatchesView()
        {
            InitializeComponent();
        }
    }
}
