namespace Rfq.CQRS.Command
{
    public record DsiCircuitOptionCommand(
        CommandType CommandType,
        ICollection<DsiCircuitOptionGrpc> DsiCircuitOptionGrpcs
    ) : ICommand<List<DbDsiCircuitOption>>;

}
