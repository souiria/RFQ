namespace Emacs.CQRS.Handler.MaterialTypes
{
    public class QueryHandler : IQueryHandler<GetMaterialTypesQuery, List<MaterialTypesGrpc>>
    {
        readonly IEMACSReadRepository<DbMaterialTypes> _Repository;
        List<MaterialTypesGrpc> _MaterialTypes;

        public QueryHandler(IEMACSReadRepository<DbMaterialTypes> repository)
        {
            _Repository = repository;
            _MaterialTypes = [];
        }
        public async Task<Result<List<MaterialTypesGrpc>>> Handle(GetMaterialTypesQuery query, CancellationToken cancellationToken)
        {
            _MaterialTypes.Clear();
            GetMaterialTypesReadOnlySpec spec = new GetMaterialTypesReadOnlySpec(query.Position, query.TakeAmount);
            List<DbMaterialTypes> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbMaterialTypes result in results)
            {
                MaterialTypesGrpc materialTypesGrpc = result.MapToMaterialTypesGrpc();
                _MaterialTypes.Add(materialTypesGrpc);
            }

            return _MaterialTypes;
        }
    }
}
