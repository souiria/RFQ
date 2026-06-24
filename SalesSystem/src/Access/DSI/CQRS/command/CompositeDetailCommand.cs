namespace DSI.CQRS.Command
{
    public record CompositeDetailCommand(
        CommandType CommandType,
        ICollection<CompositeDetailGrpc> CompositeDetailGrpcs)
        : ICommand<List<DbCompositeDetail>>;
}
