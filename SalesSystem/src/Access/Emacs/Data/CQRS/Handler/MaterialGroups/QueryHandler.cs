namespace Emacs.Data.CQRS.Handler.MaterialGroups
{
    public class QueryHandler : IQueryHandler<GetMaterialGroupsQuery, List<MaterialGroupsDto>>
    {
        readonly IEMACSReadRepository<DbMaterialGroups> _Repository;
        List<MaterialGroupsDto> _MaterialGroups;

        public QueryHandler(IEMACSReadRepository<DbMaterialGroups> repository)
        {
            _Repository = repository;
            _MaterialGroups = [];
        }

        public async Task<Result<List<MaterialGroupsDto>>> Handle(GetMaterialGroupsQuery query, CancellationToken cancellationToken)
        {
            _MaterialGroups.Clear();
            GetMaterialGroupsReadOnlySpec spec = new GetMaterialGroupsReadOnlySpec(query.Position, query.TakeAmount);
            List<DbMaterialGroups> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbMaterialGroups result in results)
            {
                MaterialGroupsDto materialGroupsDto = result.MapToMaterialGroupsDto();
                _MaterialGroups.Add(materialGroupsDto);
            }

            return _MaterialGroups;
        }
    }
}
