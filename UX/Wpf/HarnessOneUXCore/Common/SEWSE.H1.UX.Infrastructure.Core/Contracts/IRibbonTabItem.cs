namespace SEWSE.H1.UX.Infrastructure.Core.Contracts
{
    public interface IRibbonTabItem
    {
        IViewModel ViewModel { get; set; }
        bool IsSelected { get; set; }
    }
}