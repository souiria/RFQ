namespace Master.CQRS.Handler.Currency
{
    sealed class QueryHandler : IQueryHandler<GetCurrenciesQuery, List<CurrencyGrpc>>
    {
        readonly IMastersReadRepository<DbCurrency> _Repository;
        List<CurrencyGrpc> _Currencies;

        public QueryHandler(IMastersReadRepository<DbCurrency> repository)
        {
            _Repository = repository;
            _Currencies = [];
        }

        async Task<Result<List<CurrencyGrpc>>> IQueryHandler<GetCurrenciesQuery, List<CurrencyGrpc>>.Handle(GetCurrenciesQuery query, CancellationToken cancellationToken)
        {
            _Currencies.Clear();
            GetCurrenciesReadOnlySpec spec = new GetCurrenciesReadOnlySpec(query.Position, query.TakeAmount);
            List<DbCurrency> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbCurrency result in results)
            {
                CurrencyGrpc currencyGrpc = result.MapToCurrencyGrpc();
                _Currencies.Add(currencyGrpc);
            }

            return _Currencies;
        }
    }
}
