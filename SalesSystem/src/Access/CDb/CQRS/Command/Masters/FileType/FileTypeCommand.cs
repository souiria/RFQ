namespace CDb.CQRS.Command.Masters.FileType
{
    public record FileTypeCommand(CommandType CommandType, ICollection<FileTypeGrpc> FileTypeGrpcs) : ICommand;
}
