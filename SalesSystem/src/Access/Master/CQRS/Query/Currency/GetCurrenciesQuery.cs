namespace Master.CQRS.Query.Currency
{
    public class GetCurrenciesQuery : IQuery<List<CurrencyData>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
