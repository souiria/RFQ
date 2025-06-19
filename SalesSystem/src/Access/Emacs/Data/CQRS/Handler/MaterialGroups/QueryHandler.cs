namespace Emacs.Data.CQRS.Handler.MaterialGroups
{
    public class QueryHandler : IQueryHandler<GetMaterialGroupsQuery, List<MaterialGroupsData>>
    {
        readonly IEMACSReadRepository<DbMaterialGroups> _Repository;
        List<MaterialGroupsData> _MaterialGroups;

        public QueryHandler(IEMACSReadRepository<DbMaterialGroups> repository)
        {
            _Repository = repository;
            _MaterialGroups = [];
        }

        public async Task<Result<List<MaterialGroupsData>>> Handle(GetMaterialGroupsQuery query, CancellationToken cancellationToken)
        {
            _MaterialGroups.Clear();
            GetMaterialGroupsReadOnlySpec spec = new GetMaterialGroupsReadOnlySpec(query.Position, query.TakeAmount);
            List<DbMaterialGroups> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbMaterialGroups result in results)
            {
                MaterialGroupsData materialGroupsData = result.MapToMaterialGroupsData();
                _MaterialGroups.Add(materialGroupsData);
            }

            return _MaterialGroups;
        }
    }
}
