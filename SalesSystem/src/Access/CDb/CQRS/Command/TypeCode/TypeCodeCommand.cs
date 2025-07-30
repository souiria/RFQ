namespace CDb.CQRS.Command.TypeCode
{
    public record TypeCodeCommand(CommandType CommandType, ICollection<TypeCodeGrpc> TypeCodeGrpcs) : ICommand;
}
