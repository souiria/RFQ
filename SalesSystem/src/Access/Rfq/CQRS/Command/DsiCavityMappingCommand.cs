namespace Rfq.CQRS.Command
{
    public record DsiCavityMappingCommand(CommandType CommandType, ICollection<DsiCavityMappingGrpc> DsiCavityMappingGrpcs) : ICommand<List<DbDsiCavityMapping>>
    {
    }
}
