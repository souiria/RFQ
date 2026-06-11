namespace DSI.CQRS.command
{
    public record CompositeDetailCommand(
        CommandType CommandType,
        ICollection<CompositeDetailGrpc> CompositeDetailGrpcs)
        : ICommand<List<DbCompositeDetail>>;
}
