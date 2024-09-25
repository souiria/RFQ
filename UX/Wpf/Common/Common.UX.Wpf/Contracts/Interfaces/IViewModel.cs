using System.Threading.Tasks;

namespace Common.UX.Wpf.Contracts.Interfaces
{
    public interface IViewModel
    {
        string Header { get; set; }
        bool OnClosing();
    }

    public interface IViewModelAsync
    {
        string Function { get; }
        string Module { get; }
        string View { get; }
        string Header { get; set; }
        Task<bool> OnClosing();
    }
}