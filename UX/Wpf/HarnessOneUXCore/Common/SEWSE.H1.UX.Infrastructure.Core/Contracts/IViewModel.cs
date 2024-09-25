using System.Threading.Tasks;

namespace SEWSE.H1.UX.Infrastructure.Core.Contracts
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