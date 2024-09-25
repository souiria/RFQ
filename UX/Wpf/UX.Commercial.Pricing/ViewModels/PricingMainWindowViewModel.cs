namespace UX.Commercial.Pricing.ViewModels
{
    internal class PricingMainWindowViewModel : RegionViewModelBase
    {
        public PricingMainWindowViewModel(IEventAggregator eventAggregator, IRegionManager regionManager) : base(eventAggregator, regionManager)
        {
            Header = "Sales Pricing System";
        }
    }
}
