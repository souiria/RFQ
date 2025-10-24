namespace Rfq.CQRS.Command
{
    public record DsiBranchInsulationCommand(CommandType CommandType, ICollection<DsiBranchInsulationGrpc> DsiBranchInsulationGrpcs) : ICommand<List<DbDsiBranchInsulation>>
    {
    }
}
