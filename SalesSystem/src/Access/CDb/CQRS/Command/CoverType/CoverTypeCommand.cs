namespace CDb.CQRS.Command.CoverType
{
    public record CoverTypeCommand(CommandType CommandType, ICollection<CoverTypeGrpc> CoverTypeGrpcs) : ICommand;
}
