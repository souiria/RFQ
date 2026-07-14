namespace Rfq.CQRS.Command
{
    public record DsiPinMappingCavityMappingAssociationCommand(
        CommandType CommandType,
        ICollection<DsiPinMappingCavityMappingAssociationGrpc> DsiPinMappingCavityMappingAssociationGrpcs
    ) : ICommand<List<DbDsiPinMappingCavityMappingAssociation>>;

}
