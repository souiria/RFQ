namespace CDb.CQRS.Command.FuseType
{
    public record FuseTypeCommand(CommandType CommandType, ICollection<FuseTypeGrpc> FuseTypeGrpcs) : ICommand;
}
