using Prism.Commands;

namespace SEWSE.H1.UX.Infrastructure.Core
{
    public class GlobalCommands : IGlobalCommands
    {
        private CompositeCommand _createCommand = new CompositeCommand(true);
        public CompositeCommand CreateCommand => _createCommand;

        private CompositeCommand _saveCommand = new CompositeCommand(true);
        public CompositeCommand SaveCommand => _saveCommand;

        private CompositeCommand _cancelCommand = new CompositeCommand(true);
        public CompositeCommand CancelCommand => _cancelCommand;

        private CompositeCommand _deleteCommand = new CompositeCommand(true);
        public CompositeCommand DeleteCommand => _deleteCommand;

        private CompositeCommand _helpCommand = new CompositeCommand(true);
        public CompositeCommand HelpCommand => _helpCommand;

        private CompositeCommand _exportCommand = new CompositeCommand(true);
        public CompositeCommand ExportCommand => _exportCommand;
    }
}