namespace Purchasing.Services
{
    public class PurchasingAccessService : IPurchasingAccessService
    {
        #region In Memory Datasets

        #region H1CPD

        ListH1CPDGrpc _ListH1CPDGrpc;

        #endregion

        #endregion

        #region Fields and Properties

        #region H1CPD
        IQueryHandler<GetH1CPDQuery, List<H1CPDGrpc>>? _H1CPDHandler;
        bool _H1CPDRefreshInProgress;

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////

        readonly IServiceProvider _ServiceProvider;

        #endregion

        #region Constructor

        public PurchasingAccessService(IServiceProvider serviceProvider, bool testing = false)
        {
            #region H1CPDGrpc

            _ListH1CPDGrpc = new ListH1CPDGrpc();
            _H1CPDRefreshInProgress = false;

            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////
            
            _ServiceProvider = serviceProvider;

            if (testing)
            {
                PopulateSampleData();
            }
        }
        #endregion

        #region Handlers

        #region H1CPD
        public async Task<ListH1CPDGrpc> GetAllH1CPD(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListH1CPDGrpc.H1CPD.Any())
            {
                return _ListH1CPDGrpc;
            }
            else
            {
                await PopulateH1CPD(cancellationToken);
                return _ListH1CPDGrpc;
            }
        }
        #endregion

        #endregion

        #region Data Imports

        #region H1CPD
        public async Task<bool> PopulateH1CPD(CancellationToken cancellationToken)
        {
            if (!_H1CPDRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _H1CPDHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetH1CPDQuery, List<H1CPDGrpc>>>();
                    _H1CPDRefreshInProgress = true;
                    GetH1CPDQuery query = new GetH1CPDQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<H1CPDGrpc>> results = await _H1CPDHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListH1CPDGrpc.H1CPD.Clear();
                        _ListH1CPDGrpc.H1CPD.AddRange(results.Value);
                    }

                    _H1CPDRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

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
                    "H1CPDGRPC" => _ListH1CPDGrpc.H1CPD.Cast<T>().Where(func).ToList(),
                    _ => throw new NotSupportedException($"Filtering not supported for type {typeof(T).Name}")
                };
            }, cancellationToken);
        }

        void PopulateSampleData()
        {
            _ListH1CPDGrpc = SamplePurchasingDataService.PopulateH1CPDGrpc();
        }
    }
}
