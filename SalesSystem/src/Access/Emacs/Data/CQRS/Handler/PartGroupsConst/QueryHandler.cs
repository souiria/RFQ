namespace Emacs.Data.CQRS.Handler.PartGroupsConst
{
    public class QueryHandler : IQueryHandler<GetPartGroupsConstQuery, List<PartGroupsConstData>>
    {
        readonly IEMACSReadRepository<DbPartGroupsConst> _Repository;
        List<PartGroupsConstData> _PartGroupsConst;

        public QueryHandler(IEMACSReadRepository<DbPartGroupsConst> repository)
        {
            _Repository = repository;
            _PartGroupsConst = [];
        }
        public async Task<Result<List<PartGroupsConstData>>> Handle(GetPartGroupsConstQuery query, CancellationToken cancellationToken)
        {
            _PartGroupsConst.Clear();
            GetPartGroupsConstReadOnlySpec spec = new GetPartGroupsConstReadOnlySpec(query.Position, query.TakeAmount);
            List<DbPartGroupsConst> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbPartGroupsConst result in results)
            {
                PartGroupsConstData partGroupsData = result.MapToPartGroupsConstData();
                _PartGroupsConst.Add(partGroupsData);
            }

            return _PartGroupsConst;
        }
    }
}
