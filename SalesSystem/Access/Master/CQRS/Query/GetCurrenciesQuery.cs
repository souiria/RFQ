using Master.DTOs;
using MediatR;

namespace Master.CQRS.Query
{
    public class GetCurrenciesQuery : IRequest<List<CurrencyDto>>
    {
        public int? Position { get; set; }
        public int? TakeAmount { get; set; }
    }
}
