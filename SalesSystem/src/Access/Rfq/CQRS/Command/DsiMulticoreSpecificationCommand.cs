namespace Rfq.CQRS.Command
{
    public record DsiMulticoreSpecificationCommand(
        CommandType CommandType,
        ICollection<DsiMulticoreSpecificationGrpc> DsiMulticoreSpecificationGrpcs
    ) : ICommand<List<DbDsiMulticoreSpecification>>;

}
