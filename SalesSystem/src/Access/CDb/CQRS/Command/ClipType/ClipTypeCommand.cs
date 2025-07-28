namespace CDb.CQRS.Command.ClipType
{
    public record ClipTypeCommand(CommandType CommandType, ICollection<ClipTypeGrpc> ClipTypeGrpcs) : ICommand;
}
