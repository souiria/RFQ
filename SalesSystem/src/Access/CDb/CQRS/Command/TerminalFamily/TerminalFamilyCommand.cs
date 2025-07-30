namespace CDb.CQRS.Command.TerminalFamily
{
    public record TerminalFamilyCommand(CommandType CommandType, ICollection<TerminalFamilyGrpc> TerminalFamilyGrpcs) : ICommand;
}
