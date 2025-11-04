namespace Rfq.CQRS.Command
{
    public record DsiBranchConfigurationBendAssociationCommand(CommandType CommandType, ICollection<DsiBranchConfigurationBendAssociationGrpc> DsiBranchConfigurationBendAssociationGrpcs) : ICommand<List<DbDsiBranchConfigurationBendAssociation>>
    {
    }
}
