namespace Master.CQRS.Handler.SupplierGroup
{
    public class QueryHandler : IQueryHandler<GetAllSupplierGroupsQuery, List<SupplierGroupGrpc>>
    {
        readonly IMastersReadRepository<DbSupplierGroup> _Repository;
        List<SupplierGroupGrpc> _SupplierGroups;

        public QueryHandler(IMastersReadRepository<DbSupplierGroup> repository)
        {
            _Repository = repository;
            _SupplierGroups = [];
        }

        public async Task<Result<List<SupplierGroupGrpc>>> Handle(GetAllSupplierGroupsQuery query, CancellationToken cancellationToken)
        {
            _SupplierGroups.Clear();
            GetSupplierGroupReadOnlySpec spec = new GetSupplierGroupReadOnlySpec(query.Position, query.TakeAmount);
            List<DbSupplierGroup> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbSupplierGroup result in results)
            {
                SupplierGroupGrpc supplierGroupGrpc = result.MapToSupplierGroupGrpc();
                _SupplierGroups.Add(supplierGroupGrpc);
            }

            return _SupplierGroups;
        }
    }
}
