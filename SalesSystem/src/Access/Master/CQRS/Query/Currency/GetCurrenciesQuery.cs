namespace Master.CQRS.Query.Currency
{
    public class GetCurrenciesQuery : IQuery<List<CurrencyDto>>
    {
        public int? Position { get; set; }
        public int? TakeAmount { get; set; }
    }
}
