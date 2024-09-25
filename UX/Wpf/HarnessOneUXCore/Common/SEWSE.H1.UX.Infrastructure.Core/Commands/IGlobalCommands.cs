using Prism.Commands;

namespace SEWSE.H1.UX.Infrastructure.Core
{
    public interface IGlobalCommands
    {
        CompositeCommand CreateCommand { get; }
        CompositeCommand SaveCommand { get; }
        CompositeCommand CancelCommand { get; }
        CompositeCommand DeleteCommand { get; }
        CompositeCommand HelpCommand { get; }
        CompositeCommand ExportCommand { get; }
    }
}
