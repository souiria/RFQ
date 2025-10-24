namespace Rfq.CQRS.Command
{
    public record DsiWireSpecificationCommand(
        CommandType CommandType,
        ICollection<DsiWireSpecificationGrpc> DsiWireSpecificationGrpcs
    ) : ICommand<List<DbDsiWireSpecification>>;

}
