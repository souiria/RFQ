namespace Emacs.Data.CQRS.Handler.Suppliers
{
    public class QueryHandler : IQueryHandler<GetSuppliersQuery, List<SuppliersDto>>
    {
        readonly IEMACSReadRepository<DbSuppliers> _Repository;
        List<SuppliersDto> _Suppliers;

        public QueryHandler(IEMACSReadRepository<DbSuppliers> repository)
        {
            _Repository = repository;
            _Suppliers = [];
        }
        public async Task<Result<List<SuppliersDto>>> Handle(GetSuppliersQuery query, CancellationToken cancellationToken)
        {
            _Suppliers.Clear();
            GetSuppliersReadOnlySpec spec = new GetSuppliersReadOnlySpec(query.Position, query.TakeAmount);
            List<DbSuppliers> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbSuppliers result in results)
            {
                SuppliersDto suppliersDto = result.MapToSuppliersDto();
                _Suppliers.Add(suppliersDto);
            }

            return _Suppliers;
        }
    }
}
