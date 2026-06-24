namespace DSI.CQRS.Command
{
    public record WireSpecificationCommand(
        CommandType CommandType,
        ICollection<WireSpecificationGrpc> WireSpecificationGrpcs)
        : ICommand<List<DbWireSpecification>>;
}