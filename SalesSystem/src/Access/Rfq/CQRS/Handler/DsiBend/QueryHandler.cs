namespace Rfq.CQRS.Handler.DsiBend
{
    public class QueryHandler : IQueryHandler<GetDsiBendQuery, List<DsiBendGrpc>>
    {
        readonly IRfqRepository<DbDsiBend> _Repository;
        List<DsiBendGrpc> _DsiBendGrpc;

        public QueryHandler(IRfqRepository<DbDsiBend> repository)
        {
            _Repository = repository;
            _DsiBendGrpc = new List<DsiBendGrpc>();
        }

        public async Task<Result<List<DsiBendGrpc>>> Handle(GetDsiBendQuery query, CancellationToken cancellationToken)
        {
            _DsiBendGrpc.Clear();
            GetDsiBendReadOnlySpec spec = new GetDsiBendReadOnlySpec(query.Position, query.TakeAmount);
            List<DbDsiBend> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbDsiBend result in results)
            {
                DsiBendGrpc dsiBendGrpc = result.FromEntity();
                _DsiBendGrpc.Add(dsiBendGrpc);
            }

            return _DsiBendGrpc;
        }
    }
}
