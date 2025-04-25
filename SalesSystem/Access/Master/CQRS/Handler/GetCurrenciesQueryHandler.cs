using Master.Data.DTOs;
using Master.Extensions;

namespace Master.CQRS.Handler
{
    public class GetCurrenciesQueryHandler : IRequestHandler<GetCurrenciesQuery, List<CurrencyDto>>
    {
        readonly IMastersReadRepository<DbCurrency> _Repository;
        List<CurrencyDto> _ToReturn = new();

        public GetCurrenciesQueryHandler(IMastersReadRepository<DbCurrency> repository)
        {
            _Repository = repository;
        }

        public async Task<List<CurrencyDto>> Handle(GetCurrenciesQuery request, CancellationToken cancellationToken)
        {
            _ToReturn.Clear();
            List<DbCurrency> results = await _Repository.ListAsync(new GetCurrenciesReadOnlySpec(request.Position, request.TakeAmount), cancellationToken);
            foreach (DbCurrency result in results)
            {
                _ToReturn.Add(result.MapToCurrencyDto());
            }

            return _ToReturn;
        }
    }
}
