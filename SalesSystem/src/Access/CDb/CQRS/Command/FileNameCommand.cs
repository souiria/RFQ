namespace CDb.CQRS.Command
{
    public record FileNameCommand(CommandType CommandType, ICollection<FileNameGrpc> FileNameGrpcs) : ICommand;
}
