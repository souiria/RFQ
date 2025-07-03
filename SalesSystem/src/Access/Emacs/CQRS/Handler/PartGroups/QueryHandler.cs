namespace Emacs.CQRS.Handler.PartGroups
{
    public class QueryHandler : IQueryHandler<GetPartGroupsQuery, List<PartGroupsGrpc>>
    {
        readonly IEMACSReadRepository<DbPartGroups> _Repository;
        List<PartGroupsGrpc> _PartGroups;
        public QueryHandler(IEMACSReadRepository<DbPartGroups> repository)
        {
            _Repository = repository;
            _PartGroups = [];
        }
        public async Task<Result<List<PartGroupsGrpc>>> Handle(GetPartGroupsQuery query, CancellationToken cancellationToken)
        {
            _PartGroups.Clear();
            GetPartGroupsReadOnlySpec spec = new GetPartGroupsReadOnlySpec(query.Position, query.TakeAmount);
            List<DbPartGroups> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbPartGroups result in results)
            {
                PartGroupsGrpc partGroupsGrpc = result.MapToPartGroupsGrpc();
                _PartGroups.Add(partGroupsGrpc);
            }

            return _PartGroups;
        }
    }
}
