namespace CDb.CQRS.Command
{
    public record TagCommand(CommandType CommandType, ICollection<TagGrpc> TagGrpcs) : ICommand;
}
