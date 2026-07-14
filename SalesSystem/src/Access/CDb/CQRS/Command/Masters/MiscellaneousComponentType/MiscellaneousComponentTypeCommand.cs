namespace CDb.CQRS.Command.Masters.MiscellaneousComponentType
{
    public record MiscellaneousComponentTypeCommand(CommandType CommandType, ICollection<MiscellaneousComponentTypeGrpc> MiscellaneousComponentTypeGrpcs) : ICommand;
}
