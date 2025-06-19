namespace Emacs.Data.CQRS.Handler.CombinedParts
{
    public class QueryHandler : IQueryHandler<GetCombinedPartsQuery, List<CombinedPartsData>>
    {
        readonly IEMACSReadRepository<DbCombinedParts> _Repository;
        List<CombinedPartsData> _CombinedParts;

        public QueryHandler(IEMACSReadRepository<DbCombinedParts> repository)
        {
            _Repository = repository;
            _CombinedParts = [];
        }

        public async Task<Result<List<CombinedPartsData>>> Handle(GetCombinedPartsQuery query, CancellationToken cancellationToken)
        {
            _CombinedParts.Clear();
            GetCombinedPartsReadOnlySpec spec = new GetCombinedPartsReadOnlySpec(query.Position, query.TakeAmount);
            List<DbCombinedParts> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbCombinedParts result in results)
            {
                CombinedPartsData combinedPartsData = result.MapToCombinePartsData();
                _CombinedParts.Add(combinedPartsData);
            }

            return _CombinedParts;
        }
    }
}
