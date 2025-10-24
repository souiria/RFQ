namespace Rfq.CQRS.Command
{
    public record DsiMidWireComponentCommand(
        CommandType CommandType,
        ICollection<DsiMidWireComponentGrpc> DsiMidWireComponentGrpcs
    ) : ICommand<List<DbDsiMidWireComponent>>;

}
