namespace CDb.CQRS.Command.Masters.WireType
{
    public record WireTypeCommand(CommandType CommandType, ICollection<WireTypeGrpc> WireTypeGrpcs) : ICommand;
}
