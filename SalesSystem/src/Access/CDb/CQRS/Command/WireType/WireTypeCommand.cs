namespace CDb.CQRS.Command.WireType
{
    public record WireTypeCommand(CommandType CommandType, ICollection<WireTypeGrpc> WireTypeGrpcs) : ICommand;
}
