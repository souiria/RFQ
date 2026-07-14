namespace Rfq.CQRS.Command
{
    public record DsiWireThroughNodeCommand(
        CommandType CommandType,
        ICollection<DsiWireThroughNodeGrpc> DsiWireThroughNodeGrpcs
    ) : ICommand<List<DbDsiWireThroughNode>>;

}
