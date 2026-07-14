namespace CDb.CQRS.Command
{
    public record ComponentCommand(CommandType CommandType, ICollection<CompositeComponentGrpc> CompositeComponentGrpcs) : ICommand;
}
