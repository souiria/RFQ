namespace Emacs.Data.CQRS.Handler.MaterialTypes
{
    public class QueryHandler : IQueryHandler<GetMaterialTypesQuery, List<MaterialTypesData>>
    {
        readonly IEMACSReadRepository<DbMaterialTypes> _Repository;
        List<MaterialTypesData> _MaterialTypes;

        public QueryHandler(IEMACSReadRepository<DbMaterialTypes> repository)
        {
            _Repository = repository;
            _MaterialTypes = [];
        }
        public async Task<Result<List<MaterialTypesData>>> Handle(GetMaterialTypesQuery query, CancellationToken cancellationToken)
        {
            _MaterialTypes.Clear();
            GetMaterialTypesReadOnlySpec spec = new GetMaterialTypesReadOnlySpec(query.Position, query.TakeAmount);
            List<DbMaterialTypes> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbMaterialTypes result in results)
            {
                MaterialTypesData materialTypesData = result.MapToMaterialTypesData();
                _MaterialTypes.Add(materialTypesData);
            }

            return _MaterialTypes;
        }
    }
}
