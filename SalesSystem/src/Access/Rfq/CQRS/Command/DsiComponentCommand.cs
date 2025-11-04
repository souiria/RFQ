namespace Rfq.CQRS.Command
{
    public record DsiComponentCommand(
        CommandType CommandType,
        ICollection<DsiComponentGrpc> DsiComponentGrpcs
    ) : ICommand<List<DbDsiComponent>>;

}
