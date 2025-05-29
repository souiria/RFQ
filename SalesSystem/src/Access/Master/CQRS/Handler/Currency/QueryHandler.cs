namespace Master.CQRS.Handler.Currency
{
    sealed class QueryHandler : IQueryHandler<GetCurrenciesQuery, List<CurrencyDto>>
    {
        readonly IMastersReadRepository<DbCurrency> _Repository;
        List<CurrencyDto> _Currencies;

        public QueryHandler(IMastersReadRepository<DbCurrency> repository)
        {
            _Repository = repository;
            _Currencies = [];
        }

        async Task<Result<List<CurrencyDto>>> IQueryHandler<GetCurrenciesQuery, List<CurrencyDto>>.Handle(GetCurrenciesQuery query, CancellationToken cancellationToken)
        {
            _Currencies.Clear();
            GetCurrenciesReadOnlySpec spec = new GetCurrenciesReadOnlySpec(query.Position, query.TakeAmount);
            List<DbCurrency> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbCurrency result in results)
            {
                CurrencyDto currencyDto = result.MapToCurrencyDto();
                _Currencies.Add(currencyDto);
            }

            return _Currencies;
        }
    }
}
