namespace CDb.CQRS.Command.MiscellaneousComponentType
{
    public record MiscellaneousComponentTypeCommand(CommandType CommandType, ICollection<MiscellaneousComponentTypeGrpc> MiscellaneousComponentTypeGrpcs) : ICommand;
}
