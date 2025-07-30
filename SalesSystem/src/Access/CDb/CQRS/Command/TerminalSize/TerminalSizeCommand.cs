namespace CDb.CQRS.Command.TerminalSize
{
    public record TerminalSizeCommand(CommandType CommandType, ICollection<TerminalSizeGrpc> TerminalSizeGrpcs) : ICommand;
}
