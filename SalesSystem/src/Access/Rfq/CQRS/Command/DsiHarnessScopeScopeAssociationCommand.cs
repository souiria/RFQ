namespace Rfq.CQRS.Command
{
    public record DsiHarnessScopeScopeAssociationCommand(
        CommandType CommandType,
        ICollection<DsiHarnessScopeScopeAssociationGrpc> DsiHarnessScopeScopeAssociationGrpcs
    ) : ICommand<List<DbDsiHarnessScopeScopeAssociation>>;

}
