namespace CDb.CQRS.Command.Masters.CoverType
{
    public record CoverTypeCommand(CommandType CommandType, ICollection<CoverTypeGrpc> CoverTypeGrpcs) : ICommand;
}
