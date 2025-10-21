namespace Rfq.CQRS.Command
{
    public record DsiModuleChildDetailCommand(
        CommandType CommandType,
        ICollection<DsiModuleChildDetailGrpc> DsiModuleChildDetailGrpcs
    ) : ICommand<List<DbDsiModuleChildDetail>>;

}
