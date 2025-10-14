
namespace Rfq.CQRS.Handler.DsiBranchInsulation
{
    public class QueryHandler : IQueryHandler<GetDsiBranchInsulationQuery, List<DsiBranchInsulationGrpc>>
    {
        readonly IRfqRepository<DbDsiBranchInsulation> _Repository;
        List<DsiBranchInsulationGrpc> _DsiBranchInsulationGrpc;

        public QueryHandler(IRfqRepository<DbDsiBranchInsulation> repository)
        {
            _Repository = repository;
            _DsiBranchInsulationGrpc = new List<DsiBranchInsulationGrpc>();
        }

        public async Task<Result<List<DsiBranchInsulationGrpc>>> Handle(GetDsiBranchInsulationQuery query, CancellationToken cancellationToken)
        {
            _DsiBranchInsulationGrpc.Clear();
            GetDsiBranchInsulationReadOnlySpec spec = new GetDsiBranchInsulationReadOnlySpec(query.Position, query.TakeAmount);
            List<DbDsiBranchInsulation> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbDsiBranchInsulation result in results)
            {
                DsiBranchInsulationGrpc dsiBranchInsulation = result.FromEntity();
                _DsiBranchInsulationGrpc.Add(dsiBranchInsulation);
            }

            return _DsiBranchInsulationGrpc;
        }
    }
}
