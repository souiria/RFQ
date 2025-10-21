namespace Rfq.CQRS.Command
{
    public record DsiWireMulticoreMarkerCommand(
        CommandType CommandType,
        ICollection<DsiWireMulticoreMarkerGrpc> DsiWireMulticoreMarkerGrpcs
    ) : ICommand<List<DbDsiWireMulticoreMarker>>;
}
