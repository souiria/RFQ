namespace Rfq.CQRS.Command
{
    public record DsiScopeCommand(
        CommandType CommandType,
        ICollection<DsiScopeGrpc> DsiScopeGrpcs
    ) : ICommand<List<DbDsiScope>>;

}
