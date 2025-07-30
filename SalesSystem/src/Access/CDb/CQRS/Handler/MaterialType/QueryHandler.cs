namespace CDb.CQRS.Handler.MaterialType
{
    sealed class QueryHandler : IQueryHandler<GetMaterialTypesQuery, List<MaterialTypeGrpc>>
    {
        readonly ICDbRepository<DbMaterialType> _Repository;
        List<MaterialTypeGrpc> _MaterialTypes;

        public QueryHandler(ICDbRepository<DbMaterialType> repository)
        {
            _Repository = repository;
            _MaterialTypes = [];
        }

        async Task<Result<List<MaterialTypeGrpc>>> IQueryHandler<GetMaterialTypesQuery, List<MaterialTypeGrpc>>.Handle(GetMaterialTypesQuery query, CancellationToken cancellationToken)
        {
            _MaterialTypes.Clear();
            GetMaterialTypesSpecification spec = new GetMaterialTypesSpecification(query.Position, query.TakeAmount);
            List<DbMaterialType> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbMaterialType result in results)
            {
                MaterialTypeGrpc materialTypeGrpc = result.FromEntity();
                _MaterialTypes.Add(materialTypeGrpc);
            }

            return _MaterialTypes;
        }
    }
}
