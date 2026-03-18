namespace Master.CQRS.Handler.Supplier
{
    public class QueryHandler : IQueryHandler<GetAllSuppliersQuery, List<SupplierGrpc>>
    {
        readonly IMastersReadRepository<DbSupplier> _Repository;
        List<SupplierGrpc> _Suppliers;

        public QueryHandler(IMastersReadRepository<DbSupplier> repository)
        {
            _Repository = repository;
            _Suppliers = [];
        }

        public async Task<Result<List<SupplierGrpc>>> Handle(GetAllSuppliersQuery query, CancellationToken cancellationToken)
        {
            _Suppliers.Clear();
            GetSupplierReadOnlySpec spec = new GetSupplierReadOnlySpec(query.Position, query.TakeAmount);
            List<DbSupplier> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbSupplier result in results)
            {
                SupplierGrpc suppliersGrpc = result.MapToSupplierGrpc();
                _Suppliers.Add(suppliersGrpc);
            }

            return _Suppliers;
        }
    }
}
