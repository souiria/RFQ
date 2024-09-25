namespace Common.UX.Wpf.Contracts.Interfaces
{
    public interface IRibbonTabItem
    {
        IViewModel ViewModel { get; set; }
        bool IsSelected { get; set; }
    }
}