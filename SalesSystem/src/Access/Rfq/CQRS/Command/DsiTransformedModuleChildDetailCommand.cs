namespace Rfq.CQRS.Command
{
    public record DsiTransformedModuleChildDetailCommand(
        CommandType CommandType,
        ICollection<DsiTransformedModuleChildDetailGrpc> DsiTransformedModuleChildDetailGrpcs
    ) : ICommand<List<DbDsiTransformedModuleChildDetail>>;

}
