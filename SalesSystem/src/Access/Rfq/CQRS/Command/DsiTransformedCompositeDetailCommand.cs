namespace Rfq.CQRS.Command
{
    public record DsiTransformedCompositeDetailCommand(
        CommandType CommandType,
        ICollection<DsiTransformedCompositeDetailGrpc> DsiTransformedCompositeDetailGrpcs
    ) : ICommand<List<DbDsiTransformedCompositeDetail>>;

}
