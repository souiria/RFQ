namespace Emacs.Data.CQRS.Handler.PartGroups
{
    public class QueryHandler : IQueryHandler<GetPartGroupsQuery, List<PartGroupsDto>>
    {
        readonly IEMACSReadRepository<DbPartGroups> _Repository;
        List<PartGroupsDto> _PartGroups;
        public QueryHandler(IEMACSReadRepository<DbPartGroups> repository)
        {
            _Repository = repository;
            _PartGroups = [];
        }
        public async Task<Result<List<PartGroupsDto>>> Handle(GetPartGroupsQuery query, CancellationToken cancellationToken)
        {
            _PartGroups.Clear();
            GetPartGroupsReadOnlySpec spec = new GetPartGroupsReadOnlySpec(query.Position, query.TakeAmount);
            List<DbPartGroups> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbPartGroups result in results)
            {
                PartGroupsDto partGroupsDto = result.MapToPartGroupsDto();
                _PartGroups.Add(partGroupsDto);
            }

            return _PartGroups;
        }
    }
}
