namespace Rfq.CQRS.Command
{
    public record DsiCompositeDetailCircuitOptionAssociationCommand(
        CommandType CommandType,
        ICollection<DsiCompositeDetailCircuitOptionAssociationGrpc> DsiCompositeDetailCircuitOptionAssociationGrpcs
    ) : ICommand<List<DbDsiCompositeDetailCircuitOptionAssociation>>;

}
