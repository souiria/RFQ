namespace CDb.CQRS.Command.Masters.TerminalFamily
{
    public record TerminalFamilyCommand(CommandType CommandType, ICollection<TerminalFamilyGrpc> TerminalFamilyGrpcs) : ICommand;
}
