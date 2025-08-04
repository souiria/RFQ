namespace CDb.CQRS.Command.Masters.MaterialType
{
    public record MaterialTypeCommand(CommandType CommandType, ICollection<MaterialTypeGrpc> MaterialTypeGrpcs) : ICommand;
}
