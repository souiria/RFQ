namespace CDb.CQRS.Command.WireProtectionType
{
    public record WireProtectionTypeCommand(CommandType CommandType, ICollection<WireProtectionTypeGrpc> WireProtectionTypeGrpcs) : ICommand;
}
