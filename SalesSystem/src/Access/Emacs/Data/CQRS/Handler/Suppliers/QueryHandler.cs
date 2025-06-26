namespace Emacs.Data.CQRS.Handler.Suppliers
{
    public class QueryHandler : IQueryHandler<GetSuppliersQuery, List<SuppliersGrpc>>
    {
        readonly IEMACSReadRepository<DbSuppliers> _Repository;
        List<SuppliersGrpc> _Suppliers;

        public QueryHandler(IEMACSReadRepository<DbSuppliers> repository)
        {
            _Repository = repository;
            _Suppliers = [];
        }
        public async Task<Result<List<SuppliersGrpc>>> Handle(GetSuppliersQuery query, CancellationToken cancellationToken)
        {
            _Suppliers.Clear();
            GetSuppliersReadOnlySpec spec = new GetSuppliersReadOnlySpec(query.Position, query.TakeAmount);
            List<DbSuppliers> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbSuppliers result in results)
            {
                SuppliersGrpc suppliersGrpc = result.MapToSuppliersGrpc();
                _Suppliers.Add(suppliersGrpc);
            }

            return _Suppliers;
        }
    }
}
