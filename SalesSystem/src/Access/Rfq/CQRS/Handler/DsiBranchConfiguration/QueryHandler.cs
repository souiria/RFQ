
namespace Rfq.CQRS.Handler.DsiBranchConfiguration
{
    public class QueryHandler : IQueryHandler<GetDsiBranchConfigurationQuery, List<DsiBranchConfigurationGrpc>>
    {
        readonly IRfqRepository<DbDsiBranchConfiguration> _Repository;
        List<DsiBranchConfigurationGrpc> _DsiBranchConfigurationGrpc;

        public QueryHandler(IRfqRepository<DbDsiBranchConfiguration> repository)
        {
            _Repository = repository;
            _DsiBranchConfigurationGrpc = new List<DsiBranchConfigurationGrpc>();
        }

        public async Task<Result<List<DsiBranchConfigurationGrpc>>> Handle(GetDsiBranchConfigurationQuery query, CancellationToken cancellationToken)
        {
            _DsiBranchConfigurationGrpc.Clear();
            GetDsiBranchConfigurationReadOnlySpec spec = new GetDsiBranchConfigurationReadOnlySpec(query.Position, query.TakeAmount);
            List<DbDsiBranchConfiguration> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbDsiBranchConfiguration result in results)
            {
                DsiBranchConfigurationGrpc dsiBranchConfigurationGrpc = result.FromEntity();
                _DsiBranchConfigurationGrpc.Add(dsiBranchConfigurationGrpc);
            }

            return _DsiBranchConfigurationGrpc;
        }
    }
}
