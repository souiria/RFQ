namespace Rfq.CQRS.Command
{
    public record DsiPinMappingCommand(
        CommandType CommandType,
        ICollection<DsiPinMappingGrpc> DsiPinMappingGrpcs
    ) : ICommand<List<DbDsiPinMapping>>;

}
