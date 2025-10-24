namespace Rfq.CQRS.Command
{
    public record DsiUnitOfMeasureCommand(
        CommandType CommandType,
        ICollection<DsiUnitOfMeasureGrpc> DsiUnitOfMeasureGrpcs
    ) : ICommand<List<DbDsiUnitOfMeasure>>;

}
