namespace CDb.CQRS.Command.Masters.TypeCode
{
    public record TypeCodeCommand(CommandType CommandType, ICollection<TypeCodeGrpc> TypeCodeGrpcs) : ICommand;
}
