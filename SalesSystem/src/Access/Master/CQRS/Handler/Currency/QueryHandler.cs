namespace Master.CQRS.Handler.Currency
{
    sealed class QueryHandler : IQueryHandler<GetCurrenciesQuery, List<CurrencyData>>
    {
        readonly IMastersReadRepository<DbCurrency> _Repository;
        List<CurrencyData> _Currencies;

        public QueryHandler(IMastersReadRepository<DbCurrency> repository)
        {
            _Repository = repository;
            _Currencies = [];
        }

        async Task<Result<List<CurrencyData>>> IQueryHandler<GetCurrenciesQuery, List<CurrencyData>>.Handle(GetCurrenciesQuery query, CancellationToken cancellationToken)
        {
            _Currencies.Clear();
            GetCurrenciesReadOnlySpec spec = new GetCurrenciesReadOnlySpec(query.Position, query.TakeAmount);
            List<DbCurrency> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbCurrency result in results)
            {
                CurrencyData currencyData = result.MapToCurrencyData();
                _Currencies.Add(currencyData);
            }

            return _Currencies;
        }
    }
}
