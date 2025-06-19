namespace Emacs.Data.CQRS.Handler.PartGroups
{
    public class QueryHandler : IQueryHandler<GetPartGroupsQuery, List<PartGroupsData>>
    {
        readonly IEMACSReadRepository<DbPartGroups> _Repository;
        List<PartGroupsData> _PartGroups;
        public QueryHandler(IEMACSReadRepository<DbPartGroups> repository)
        {
            _Repository = repository;
            _PartGroups = [];
        }
        public async Task<Result<List<PartGroupsData>>> Handle(GetPartGroupsQuery query, CancellationToken cancellationToken)
        {
            _PartGroups.Clear();
            GetPartGroupsReadOnlySpec spec = new GetPartGroupsReadOnlySpec(query.Position, query.TakeAmount);
            List<DbPartGroups> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbPartGroups result in results)
            {
                PartGroupsData partGroupsData = result.MapToPartGroupsData();
                _PartGroups.Add(partGroupsData);
            }

            return _PartGroups;
        }
    }
}
