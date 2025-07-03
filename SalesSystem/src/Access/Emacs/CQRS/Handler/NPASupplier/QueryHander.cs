namespace Emacs.CQRS.Handler.NPASupplier
{
    public class QueryHander : IQueryHandler<GetNPASupplierQuery, List<NPASupplierGrpc>>
    {
        readonly IEMACSReadRepository<DbNPASupplier> _Repository;
        List<NPASupplierGrpc> _NPASupplier;

        public QueryHander(IEMACSReadRepository<DbNPASupplier> repository)
        {
            _Repository = repository;
            _NPASupplier = [];
        }
        public async Task<Result<List<NPASupplierGrpc>>> Handle(GetNPASupplierQuery query, CancellationToken cancellationToken)
        {
            _NPASupplier.Clear();
            GetNPASupplierReadOnlySpec spec = new GetNPASupplierReadOnlySpec(query.Position, query.TakeAmount);
            List<DbNPASupplier> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbNPASupplier result in results)
            {
                NPASupplierGrpc nPASupplierGrpc = result.MapToNPASupplierGrpc();
                _NPASupplier.Add(nPASupplierGrpc);
            }

            return _NPASupplier;
        }
    }
}
