using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UX.Commercial.Pricing.ViewModels;

namespace UX.Commercial.Pricing.RibbonTabs.ViewModels;
internal class WelcomeViewModel : RegionViewModelBase
{
    public WelcomeViewModel(IEventAggregator eventAggregator, IRegionManager regionManager) : base(eventAggregator, regionManager)
    {
        Header = "Welcome";
    }
}
