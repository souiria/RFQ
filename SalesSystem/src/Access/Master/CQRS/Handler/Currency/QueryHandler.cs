namespace Master.CQRS.Handler.Currency
{
    sealed class QueryHandler : IQueryHandler<GetCurrenciesQuery, List<CurrencyDto>>
    {
        readonly IMastersReadRepository<DbCurrency> _Repository;
        List<CurrencyDto> _Currencies = new();

        public QueryHandler(IMastersReadRepository<DbCurrency> repository)
        {
            _Repository = repository;
        }

        async Task<Result<List<CurrencyDto>>> IQueryHandler<GetCurrenciesQuery, List<CurrencyDto>>.Handle(GetCurrenciesQuery query, CancellationToken cancellationToken)
        {
            _Currencies.Clear();
            List<DbCurrency> results = await _Repository.ListAsync(new GetCurrenciesReadOnlySpec(query.Position, query.TakeAmount), cancellationToken);
            foreach (DbCurrency result in results)
            {
                _Currencies.Add(result.MapToCurrencyDto());
            }

            return _Currencies;
        }
    }
}
