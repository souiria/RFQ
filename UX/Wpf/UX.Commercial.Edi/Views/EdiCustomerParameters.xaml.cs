using Common.UX.Wpf.Attributes;
using UX.Commercial.Edi.RibbonTabs.Views;

namespace UX.Commercial.Edi.Views;
/// <summary>
/// Interaction logic for EdiCustomerParameters.xaml
/// </summary>
[RibbonTab(typeof(CustomerParameterTab))]
public partial class EdiCustomerParameters
{
    public EdiCustomerParameters()
    {
        InitializeComponent();
    }
}
