namespace Emacs.Data.CQRS.Handler.MaterialTypes
{
    public class QueryHandler : IQueryHandler<GetMaterialTypesQuery, List<MaterialTypesDto>>
    {
        readonly IEMACSReadRepository<DbMaterialTypes> _Repository;
        List<MaterialTypesDto> _MaterialTypes;

        public QueryHandler(IEMACSReadRepository<DbMaterialTypes> repository)
        {
            _Repository = repository;
            _MaterialTypes = [];
        }
        public async Task<Result<List<MaterialTypesDto>>> Handle(GetMaterialTypesQuery query, CancellationToken cancellationToken)
        {
            _MaterialTypes.Clear();
            GetMaterialTypesReadOnlySpec spec = new GetMaterialTypesReadOnlySpec(query.Position, query.TakeAmount);
            List<DbMaterialTypes> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbMaterialTypes result in results)
            {
                MaterialTypesDto materialTypesDto = result.MapToMaterialTypesDto();
                _MaterialTypes.Add(materialTypesDto);
            }

            return _MaterialTypes;
        }
    }
}
