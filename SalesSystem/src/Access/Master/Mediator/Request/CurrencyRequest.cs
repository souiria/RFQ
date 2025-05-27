namespace Master.Mediator.Request
{
    public class CurrencyRequest : RequestBase, IQuery<List<CurrencyDto>>
    {
        public CurrencyRequestType RequestType { get; set; }
    }

    public enum CurrencyRequestType
    {
        CheckForHeartBeat,
        GetAllCurrencies
    }
}
