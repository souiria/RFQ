namespace Emacs.CQRS.Handler.CombinedParts
{
    public class QueryHandler : IQueryHandler<GetCombinedPartsQuery, List<CombinedPartsGrpc>>
    {
        readonly IEMACSReadRepository<DbCombinedParts> _Repository;
        List<CombinedPartsGrpc> _CombinedParts;

        public QueryHandler(IEMACSReadRepository<DbCombinedParts> repository)
        {
            _Repository = repository;
            _CombinedParts = [];
        }

        public async Task<Result<List<CombinedPartsGrpc>>> Handle(GetCombinedPartsQuery query, CancellationToken cancellationToken)
        {
            _CombinedParts.Clear();
            GetCombinedPartsReadOnlySpec spec = new GetCombinedPartsReadOnlySpec(query.Position, query.TakeAmount);
            List<DbCombinedParts> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbCombinedParts result in results)
            {
                CombinedPartsGrpc combinedPartsGrpc = result.MapToCombinePartsGrpc();
                _CombinedParts.Add(combinedPartsGrpc);
            }

            return _CombinedParts;
        }
    }
}
