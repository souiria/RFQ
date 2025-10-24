namespace Rfq.CQRS.Command
{
    public record DsiSupplierCommand(
        CommandType CommandType,
        ICollection<DsiSupplierGrpc> DsiSupplierGrpcs
    ) : ICommand<List<DbDsiSupplier>>;

}
