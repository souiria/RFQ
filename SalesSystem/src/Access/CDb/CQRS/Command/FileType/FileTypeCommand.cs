namespace CDb.CQRS.Command.FileType
{
    public record FileTypeCommand(CommandType CommandType, ICollection<FileTypeGrpc> FileTypeGrpcs) : ICommand;
}
