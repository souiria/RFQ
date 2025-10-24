namespace Rfq.CQRS.Command
{
    public record DsiManualBomQuantityCommand(
        CommandType CommandType,
        ICollection<DsiManualBomQuantityGrpc> DsiManualBomQuantityGrpcs
    ) : ICommand<List<DbDsiManualBomQuantity>>;

}
