
namespace Rfq.CQRS.Handler.DsiBranchInsulationThroughNode
{
    public class QueryHandler : IQueryHandler<GetDsiBranchInsulationThroughNodeQuery, List<DsiBranchInsulationThroughNodeGrpc>>
    {
        readonly IRfqRepository<DbDsiBranchInsulationThroughNode> _Repository;
        List<DsiBranchInsulationThroughNodeGrpc> _DsiBranchInsulationThroughNodeGrpc;

        public QueryHandler(IRfqRepository<DbDsiBranchInsulationThroughNode> repository)
        {
            _Repository = repository;
            _DsiBranchInsulationThroughNodeGrpc = new List<DsiBranchInsulationThroughNodeGrpc>();
        }

        public async Task<Result<List<DsiBranchInsulationThroughNodeGrpc>>> Handle(GetDsiBranchInsulationThroughNodeQuery query, CancellationToken cancellationToken)
        {
            _DsiBranchInsulationThroughNodeGrpc.Clear();
            GetDsiBranchInsulationThroughNodeReadOnlySpec spec = new GetDsiBranchInsulationThroughNodeReadOnlySpec(query.Position, query.TakeAmount);
            List<DbDsiBranchInsulationThroughNode> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbDsiBranchInsulationThroughNode result in results)
            {
                DsiBranchInsulationThroughNodeGrpc dsiBranchInsulationThroughNode = result.FromEntity();
                _DsiBranchInsulationThroughNodeGrpc.Add(dsiBranchInsulationThroughNode);
            }

            return _DsiBranchInsulationThroughNodeGrpc;
        }
    }
}
