namespace UX.Commercial.Quotation.ViewModels
{
    internal class QuotationMainWindowViewModel : RegionViewModelBase
    {
        public QuotationMainWindowViewModel(IEventAggregator eventAggregator, IRegionManager regionManager) : base(eventAggregator, regionManager)
        {
            Header = "Sales Quotation System";
        }
    }
}
