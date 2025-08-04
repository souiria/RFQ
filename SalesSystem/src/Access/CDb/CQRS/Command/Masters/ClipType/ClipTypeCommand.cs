namespace CDb.CQRS.Command.Masters.ClipType
{
    public record ClipTypeCommand(CommandType CommandType, ICollection<ClipTypeGrpc> ClipTypeGrpcs) : ICommand;
}
