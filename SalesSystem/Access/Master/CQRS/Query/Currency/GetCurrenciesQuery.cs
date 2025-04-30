using Master.Data.DTOs;

namespace Master.CQRS.Query.Currency
{
    public class GetCurrenciesQuery : IRequest<List<CurrencyDto>>
    {
        public int? Position { get; set; }
        public int? TakeAmount { get; set; }
    }
}
