using System.Threading.Tasks;
using System.Windows.Input;

namespace Common.UX.Wpf.Contracts.Interfaces
{
    public interface IAsyncCommand : IAsyncCommand<object>
    {
    }

    public interface IAsyncCommand<in T>
    {
        Task ExecuteAsync(T obj);
        bool CanExecute(object obj);
        ICommand Command { get; }
    }
}
