using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UX.Commercial.Pricing.RibbonTabs.Views;

namespace UX.Commercial.Pricing.Views
{
    /// <summary>
    /// Interaction logic for PricingMainWindow.xaml
    /// </summary>
    [RibbonTab(typeof(SalesPricingRibbonTab))]
    public partial class PricingMainWindow : UserControl
    {
        public PricingMainWindow()
        {
            InitializeComponent();
        }
    }
}
