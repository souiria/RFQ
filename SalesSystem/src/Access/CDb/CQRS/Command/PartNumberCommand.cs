namespace CDb.CQRS.Command
{
    public record PartNumberCommand(CommandType CommandType, ICollection<PartNumberGrpc> PartNumberGrpcs) : ICommand;
}
