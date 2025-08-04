namespace CDb.CQRS.Command.Masters.TerminalSize
{
    public record TerminalSizeCommand(CommandType CommandType, ICollection<TerminalSizeGrpc> TerminalSizeGrpcs) : ICommand;
}
