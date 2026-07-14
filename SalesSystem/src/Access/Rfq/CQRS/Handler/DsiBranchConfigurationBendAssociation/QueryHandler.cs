
namespace Rfq.CQRS.Handler.DsiBranchConfigurationBendAssociation
{
    public class QueryHandler : IQueryHandler<GetDsiBranchConfigurationBendAssociationQuery, List<DsiBranchConfigurationBendAssociationGrpc>>
    {
        readonly IRfqRepository<DbDsiBranchConfigurationBendAssociation> _Repository;
        List<DsiBranchConfigurationBendAssociationGrpc> _DsiBranchConfigurationBendAssociationGrpc;

        public QueryHandler(IRfqRepository<DbDsiBranchConfigurationBendAssociation> repository)
        {
            _Repository = repository;
            _DsiBranchConfigurationBendAssociationGrpc = new List<DsiBranchConfigurationBendAssociationGrpc>();
        }

        public async Task<Result<List<DsiBranchConfigurationBendAssociationGrpc>>> Handle(GetDsiBranchConfigurationBendAssociationQuery query, CancellationToken cancellationToken)
        {
            _DsiBranchConfigurationBendAssociationGrpc.Clear();
            GetDsiBranchConfigurationBendAssociationReadOnlySpec spec = new GetDsiBranchConfigurationBendAssociationReadOnlySpec(query.Position, query.TakeAmount);
            List<DbDsiBranchConfigurationBendAssociation> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbDsiBranchConfigurationBendAssociation result in results)
            {
                DsiBranchConfigurationBendAssociationGrpc dsiBranchConfigurationBendAssociationGrpc = result.FromEntity();
                _DsiBranchConfigurationBendAssociationGrpc.Add(dsiBranchConfigurationBendAssociationGrpc);
            }

            return _DsiBranchConfigurationBendAssociationGrpc;
        }
    }
}
