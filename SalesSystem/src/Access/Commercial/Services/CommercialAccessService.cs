namespace Commercial.Services
{
    public class CommercialAccessService : ICommercialAccessService
    {
        #region In Memory Datasets

        #region PurchaseOrders

        ListPurchaseOrderDataGrpc _ListPurchaseOrders;

        #endregion

        #endregion

        #region Fields and Properties

        #region PurchaseOrders
        IQueryHandler<GetAllPurchaseOrdersQuery, List<PurchaseOrderDataGrpc>>? _PurchaseOrderHandler;
        bool _PurchaseOrderRefreshInProgress;
        #endregion

        readonly IServiceProvider _ServiceProvider;
        readonly ILogger<CommercialAccessService> _Logger;
        #endregion

        #region Constructor

        public CommercialAccessService(IServiceProvider serviceProvider, ILogger<CommercialAccessService> logger, bool testing = false)
        {
            #region PurchaseOrders

            _ListPurchaseOrders = new ListPurchaseOrderDataGrpc();
            _PurchaseOrderRefreshInProgress = false;

            #endregion

            _ServiceProvider = serviceProvider;
            _Logger = logger;
            if (testing)
            {
                PopulateSampleData();
            }
        }

        #endregion

        #region Handlers

        #region PurchaseOrders

        public async Task<ListPurchaseOrderDataGrpc> GetAllPurchaseOrdersAsync(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListPurchaseOrders.PurchaseOrderData.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListPurchaseOrders;
                }

                ListPurchaseOrderDataGrpc returnList = new ListPurchaseOrderDataGrpc();
                IQueryable<PurchaseOrderDataGrpc> query = _ListPurchaseOrders.PurchaseOrderData.AsQueryable().Skip(position).Take(takeAmount);
                returnList.PurchaseOrderData.AddRange(query);
                return returnList;
            }
            else
            {
                await PopulatePurchaseOrdersAsync(cancellationToken);
                return _ListPurchaseOrders;
            }
        }

        #endregion

        #region Data Imports

        public async Task<bool> PopulatePurchaseOrdersAsync(CancellationToken cancellationToken)
        {
            if (!_PurchaseOrderRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _PurchaseOrderHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetAllPurchaseOrdersQuery, List<PurchaseOrderDataGrpc>>>();
                    _PurchaseOrderRefreshInProgress = true;
                    GetAllPurchaseOrdersQuery query = new GetAllPurchaseOrdersQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<PurchaseOrderDataGrpc>> results = await _PurchaseOrderHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListPurchaseOrders.PurchaseOrderData.Clear();
                        _ListPurchaseOrders.PurchaseOrderData.AddRange(results.Value);
                    }

                    _PurchaseOrderRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        #endregion

        public async Task HandleFilterCase<T>(string filterExpressionString, ParsingConfig parsingConfig, Action<IEnumerable<T>> setResponseCollection,
        CancellationToken cancellationToken)
        {
            Expression<Func<T, bool>> filterExpression = DynamicExpressionParser.ParseLambda<T, bool>(parsingConfig, false, filterExpressionString);
            Func<T, bool> compiledExpression = filterExpression.Compile();
            IEnumerable<T> filteredList = new List<T>();
            filteredList = await Filter(compiledExpression, cancellationToken);
            setResponseCollection(filteredList);
        }

        public async Task<IEnumerable<T>> Filter<T>(Func<T, bool> func, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                return typeof(T).Name.ToUpperInvariant() switch
                {
                    "PURCHASEORDERDATAGRPC" => _ListPurchaseOrders.PurchaseOrderData.Cast<T>().Where(func).ToList(),
                    _ => throw new NotSupportedException($"Filtering not supported for type {typeof(T).Name}")
                };
            }, cancellationToken);
        }

        #endregion
        public void PopulateSampleData()
        {
            _ListPurchaseOrders = SampleCommercialDataService.PopulatePurchaseOrderData();
        }
    }
}
