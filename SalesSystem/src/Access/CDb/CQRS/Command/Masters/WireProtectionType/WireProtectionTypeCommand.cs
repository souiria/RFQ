namespace CDb.CQRS.Command.Masters.WireProtectionType
{
    public record WireProtectionTypeCommand(CommandType CommandType, ICollection<WireProtectionTypeGrpc> WireProtectionTypeGrpcs) : ICommand;
}
