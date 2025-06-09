namespace Emacs.Data.CQRS.Handler.CombinedParts
{
    public class QueryHandler : IQueryHandler<GetCombinedPartsQuery, List<CombinedPartsDto>>
    {
        readonly IEMACSReadRepository<DbCombinedParts> _Repository;
        List<CombinedPartsDto> _CombinedParts;

        public QueryHandler(IEMACSReadRepository<DbCombinedParts> repository)
        {
            _Repository = repository;
            _CombinedParts = [];
        }

        public async Task<Result<List<CombinedPartsDto>>> Handle(GetCombinedPartsQuery query, CancellationToken cancellationToken)
        {
            _CombinedParts.Clear();
            GetCombinedPartsReadOnlySpec spec = new GetCombinedPartsReadOnlySpec(query.Position, query.TakeAmount);
            List<DbCombinedParts> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbCombinedParts result in results)
            {
                CombinedPartsDto currencyDto = result.MapToCurrencyDto();
                _CombinedParts.Add(currencyDto);
            }

            return _CombinedParts;
        }
    }
}
