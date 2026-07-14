namespace Rfq.CQRS.Command
{
    public record DsiCompositeDetailCommand(
        CommandType CommandType,
        ICollection<DsiCompositeDetailGrpc> DsiCompositeDetailGrpcs
    ) : ICommand<List<DbDsiCompositeDetail>>;

}
