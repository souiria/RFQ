namespace Emacs.Data.CQRS.Handler.Suppliers
{
    public class QueryHandler : IQueryHandler<GetSuppliersQuery, List<SuppliersData>>
    {
        readonly IEMACSReadRepository<DbSuppliers> _Repository;
        List<SuppliersData> _Suppliers;

        public QueryHandler(IEMACSReadRepository<DbSuppliers> repository)
        {
            _Repository = repository;
            _Suppliers = [];
        }
        public async Task<Result<List<SuppliersData>>> Handle(GetSuppliersQuery query, CancellationToken cancellationToken)
        {
            _Suppliers.Clear();
            GetSuppliersReadOnlySpec spec = new GetSuppliersReadOnlySpec(query.Position, query.TakeAmount);
            List<DbSuppliers> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbSuppliers result in results)
            {
                SuppliersData suppliersData = result.MapToSuppliersData();
                _Suppliers.Add(suppliersData);
            }

            return _Suppliers;
        }
    }
}
