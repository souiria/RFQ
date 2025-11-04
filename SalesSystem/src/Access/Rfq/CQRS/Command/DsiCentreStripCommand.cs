namespace Rfq.CQRS.Command
{
    public record DsiCentreStripCommand(
        CommandType CommandType,
        ICollection<DsiCentreStripGrpc> DsiCentreStripGrpcs
    ) : ICommand<List<DbDsiCentreStrip>>;

}
