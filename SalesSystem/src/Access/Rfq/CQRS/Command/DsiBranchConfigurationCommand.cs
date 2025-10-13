namespace Rfq.CQRS.Command
{
    public record DsiBranchConfigurationCommand(CommandType CommandType, ICollection<DsiBranchConfigurationGrpc> DsiBranchConfigurationGrpc) : ICommand<List<DbDsiBranchConfiguration>>
    {
    }
}
