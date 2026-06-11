namespace DSI.CQRS.command
{
    public record WireSpecificationCommand(
        CommandType CommandType,
        ICollection<WireSpecificationGrpc> WireSpecificationGrpcs)
        : ICommand<List<DbWireSpecification>>;
}