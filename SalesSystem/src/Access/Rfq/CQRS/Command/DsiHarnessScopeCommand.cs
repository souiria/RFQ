namespace Rfq.CQRS.Command
{
    public record DsiHarnessScopeCommand(
        CommandType CommandType,
        ICollection<DsiHarnessScopeGrpc> DsiHarnessScopeGrpcs
    ) : ICommand<List<DbDsiHarnessScope>>;

}
