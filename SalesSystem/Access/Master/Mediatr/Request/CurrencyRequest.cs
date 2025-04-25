namespace Master.Mediatr.Request
{
    public class CurrencyRequest : RequestBase, IRequest<List<CurrencyDto>>
    {
        public CurrencyRequestType RequestType { get; set; }
    }

    public enum CurrencyRequestType
    {
        CheckForHeartBeat,
        GetAllCurrencies
    }
}
