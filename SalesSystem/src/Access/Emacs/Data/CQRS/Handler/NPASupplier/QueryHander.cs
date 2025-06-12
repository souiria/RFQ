namespace Emacs.Data.CQRS.Handler.NPASupplier
{
    public class QueryHander : IQueryHandler<GetNPASupplierQuery, List<NPASupplierDto>>
    {
        readonly IEMACSReadRepository<DbNPASupplier> _Repository;
        List<NPASupplierDto> _NPASupplier;

        public QueryHander(IEMACSReadRepository<DbNPASupplier> repository)
        {
            _Repository = repository;
            _NPASupplier = [];
        }
        public async Task<Result<List<NPASupplierDto>>> Handle(GetNPASupplierQuery query, CancellationToken cancellationToken)
        {
            _NPASupplier.Clear();
            GetNPASupplierReadOnlySpec spec = new GetNPASupplierReadOnlySpec(query.Position, query.TakeAmount);
            List<DbNPASupplier> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbNPASupplier result in results)
            {
                NPASupplierDto nPASupplierDto = result.MapToNPASupplierDto();
                _NPASupplier.Add(nPASupplierDto);
            }

            return _NPASupplier;
        }
    }
}
