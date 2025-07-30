namespace CDb.CQRS.Command.MaterialType
{
    public record MaterialTypeCommand(CommandType CommandType, ICollection<MaterialTypeGrpc> MaterialTypeGrpcs) : ICommand;
}
