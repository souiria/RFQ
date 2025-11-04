namespace Rfq.CQRS.Command
{
    public record DsiCompositeOptionCommand(
        CommandType CommandType,
        ICollection<DsiCompositeOptionGrpc> DsiCompositeOptionGrpcs
    ) : ICommand<List<DbDsiCompositeOption>>;

}
