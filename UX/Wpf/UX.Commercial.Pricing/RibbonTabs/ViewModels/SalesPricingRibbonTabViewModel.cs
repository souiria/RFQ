using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UX.Commercial.Pricing.Core.Regions;

namespace UX.Commercial.Pricing.RibbonTabs.ViewModels;
internal class SalesPricingRibbonTabViewModel : BindableBase
{
    private readonly IRegionManager _regionManager;
    public string Header { get; set; } = "Sales Pricing";
    public string HelpdeskCaption { get; set; } = "Helpdesk";
    public string HelpCaption { get; set; } = "Help";

    public SalesPricingRibbonTabViewModel(IRegionManager regionManager)
    {
        _regionManager = regionManager;
        _regionManager.Regions[PricingRegionNames.SalesPricingTabGroup].RequestNavigate("Welcome");
    }

}
