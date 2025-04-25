namespace Master.Services
{
    /// <summary>
    /// This class is used to make calls to the database queries and to hold the data dictionaries.
    /// It is used by both the Grpc and Http api services
    /// </summary>
    public class MasterAccessService : IRequestHandler<CurrencyRequest, List<CurrencyDto>>,
        IRequestHandler<PopulateMasterDataRequest, bool>
    {
        readonly IMediator _Mediator;

        #region In Memory Datasets

        List<CurrencyDto> _Currencies;

        #endregion

        #region Fields and Properties

        bool _CurrencyRefreshInProgress;

        #endregion

        public MasterAccessService(IMediator mediator)
        {
            _Mediator = mediator;
            _Currencies = [];
            _CurrencyRefreshInProgress = false;
        }

        #region Handlers

        public async Task<List<CurrencyDto>> Handle(CurrencyRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_Currencies.Any())
            {
                return _Currencies;
            }
            else
            {
                await PopulateCurrenciesAsync(cancellationToken);
                return _Currencies;
            }
        }

        public async Task<bool> Handle(PopulateMasterDataRequest request, CancellationToken cancellationToken)
        {
            await PopulateCurrenciesAsync(cancellationToken);
            return true;
        }

        #endregion

        #region Data Imports

        public async Task PopulateCurrenciesAsync(CancellationToken cancellationToken)
        {
            if (!_CurrencyRefreshInProgress)
            {
                _CurrencyRefreshInProgress = true;
                await Task.Delay(1, cancellationToken);
                List<CurrencyDto> results = await _Mediator.Send(new GetCurrenciesQuery(), cancellationToken);
                _Currencies = results;
                _CurrencyRefreshInProgress = false;
            }
        }

        #endregion
    }
}
