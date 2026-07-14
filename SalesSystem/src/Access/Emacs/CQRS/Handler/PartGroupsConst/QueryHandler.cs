namespace Emacs.CQRS.Handler.PartGroupsConst
{
    public class QueryHandler : IQueryHandler<GetPartGroupsConstQuery, List<PartGroupsConstGrpc>>
    {
        readonly IEMACSReadRepository<DbPartGroupsConst> _Repository;
        List<PartGroupsConstGrpc> _PartGroupsConst;

        public QueryHandler(IEMACSReadRepository<DbPartGroupsConst> repository)
        {
            _Repository = repository;
            _PartGroupsConst = [];
        }
        public async Task<Result<List<PartGroupsConstGrpc>>> Handle(GetPartGroupsConstQuery query, CancellationToken cancellationToken)
        {
            _PartGroupsConst.Clear();
            GetPartGroupsConstReadOnlySpec spec = new GetPartGroupsConstReadOnlySpec(query.Position, query.TakeAmount);
            List<DbPartGroupsConst> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbPartGroupsConst result in results)
            {
                PartGroupsConstGrpc partGroupsGrpc = result.MapToPartGroupsConstGrpc();
                _PartGroupsConst.Add(partGroupsGrpc);
            }

            return _PartGroupsConst;
        }
    }
}
