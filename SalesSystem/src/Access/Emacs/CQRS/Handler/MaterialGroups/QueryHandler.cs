namespace Emacs.CQRS.Handler.MaterialGroups
{
    public class QueryHandler : IQueryHandler<GetMaterialGroupsQuery, List<MaterialGroupsGrpc>>
    {
        readonly IEMACSReadRepository<DbMaterialGroups> _Repository;
        List<MaterialGroupsGrpc> _MaterialGroups;

        public QueryHandler(IEMACSReadRepository<DbMaterialGroups> repository)
        {
            _Repository = repository;
            _MaterialGroups = [];
        }

        public async Task<Result<List<MaterialGroupsGrpc>>> Handle(GetMaterialGroupsQuery query, CancellationToken cancellationToken)
        {
            _MaterialGroups.Clear();
            GetMaterialGroupsReadOnlySpec spec = new GetMaterialGroupsReadOnlySpec(query.Position, query.TakeAmount);
            List<DbMaterialGroups> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbMaterialGroups result in results)
            {
                MaterialGroupsGrpc materialGroupsGrpc = result.MapToMaterialGroupsGrpc();
                _MaterialGroups.Add(materialGroupsGrpc);
            }

            return _MaterialGroups;
        }
    }
}
