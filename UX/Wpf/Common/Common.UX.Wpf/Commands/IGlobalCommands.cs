using Prism.Commands;

namespace Common.UX.Wpf.Commands
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
