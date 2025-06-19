namespace Emacs.Data.CQRS.Handler.NPASupplier
{
    public class QueryHander : IQueryHandler<GetNPASupplierQuery, List<NPASupplierData>>
    {
        readonly IEMACSReadRepository<DbNPASupplier> _Repository;
        List<NPASupplierData> _NPASupplier;

        public QueryHander(IEMACSReadRepository<DbNPASupplier> repository)
        {
            _Repository = repository;
            _NPASupplier = [];
        }
        public async Task<Result<List<NPASupplierData>>> Handle(GetNPASupplierQuery query, CancellationToken cancellationToken)
        {
            _NPASupplier.Clear();
            GetNPASupplierReadOnlySpec spec = new GetNPASupplierReadOnlySpec(query.Position, query.TakeAmount);
            List<DbNPASupplier> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbNPASupplier result in results)
            {
                NPASupplierData nPASupplierData = result.MapToNPASupplierData();
                _NPASupplier.Add(nPASupplierData);
            }

            return _NPASupplier;
        }
    }
}
