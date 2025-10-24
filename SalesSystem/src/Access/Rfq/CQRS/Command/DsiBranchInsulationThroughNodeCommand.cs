namespace Rfq.CQRS.Command
{
    public record DsiBranchInsulationThroughNodeCommand(CommandType CommandType, ICollection<DsiBranchInsulationThroughNodeGrpc> DsiBranchInsulationThroughNodeGrpcs) : ICommand<List<DbDsiBranchInsulationThroughNode>>
    {
    }
}
