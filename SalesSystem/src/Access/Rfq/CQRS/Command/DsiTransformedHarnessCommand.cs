namespace Rfq.CQRS.Command
{
    public record DsiTransformedHarnessCommand(
        CommandType CommandType,
        ICollection<DsiTransformedHarnessGrpc> DsiTransformedHarnessGrpcs
    ) : ICommand<List<DbDsiTransformedHarness>>;

}
