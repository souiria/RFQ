namespace CDb.CQRS.Command.Masters.FuseType
{
    public record FuseTypeCommand(CommandType CommandType, ICollection<FuseTypeGrpc> FuseTypeGrpcs) : ICommand;
}
