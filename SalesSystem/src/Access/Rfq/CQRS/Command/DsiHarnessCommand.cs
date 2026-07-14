namespace Rfq.CQRS.Command
{
    public record DsiHarnessCommand(
        CommandType CommandType,
        ICollection<DsiHarnessGrpc> DsiHarnessGrpcs
    ) : ICommand<List<DbDsiHarness>>;

}
