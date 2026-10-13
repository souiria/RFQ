namespace CPD.Services
{
    public class CPDAccessService : ICPDAccessService
    {
        #region In Memory Datasets

        #region MatSuppMst

        ListMatSuppMstGrpc _ListMatSuppMstView;
        #endregion

        #region HarnessCostingCalculationData

        ListHarnessCostingCalculationDataGrpc _ListHarnessCostingCalculationDataView;
        #endregion

        #endregion

        #region Fields and Properties

        #region MatSuppMst

        IQueryHandler<GetMattSuppMstViewQuery, List<MatSuppMstViewGrpc>>? _MatSuppMstViewHandler;
        bool _MatSuppMstViewRefreshInProgress;
        #endregion

        #region HarnessCostingCalculationData

        IQueryHandler<GetHarnessCostingCalculationDataViewQuery, List<HarnessCostingCalculationDataGrpc>>? _HarnessCostingCalculationDataViewHandler;
        bool _HarnessCostingCalculationDataViewRefreshInProgress;
        #endregion

        readonly IServiceProvider _ServiceProvider;
        #endregion

        #region Constructor
        public CPDAccessService(IServiceProvider serviceProvider, bool testing = false)
        {
            #region MatSuppMst
            _ListMatSuppMstView = new ListMatSuppMstGrpc();
            _MatSuppMstViewRefreshInProgress = false;
            #endregion

            #region HarnessCostingCalculationData
            _ListHarnessCostingCalculationDataView = new ListHarnessCostingCalculationDataGrpc();
            _HarnessCostingCalculationDataViewRefreshInProgress = false;
            #endregion

            _ServiceProvider = serviceProvider;

            if (testing)
            {
                PopulateSampleData();
            }
        }
        #endregion

        #region Handlers

        #region MatSuppMst
        public async Task<ListMatSuppMstGrpc> GetAllMatSuppMstView(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(0, cancellationToken);
            if (_ListMatSuppMstView.MatSuppMstViewGrpc.Any())
            {
                if(takeAmount <= 0)
                {
                    return _ListMatSuppMstView;
                }

                ListMatSuppMstGrpc returnList = new ListMatSuppMstGrpc();
                IQueryable<MatSuppMstViewGrpc> query = _ListMatSuppMstView.MatSuppMstViewGrpc.AsQueryable().Skip(position).Take(takeAmount);
                returnList.MatSuppMstViewGrpc.AddRange(query);
                return returnList;
            }
            else
            {
                await PopulateMatSuppMstView(cancellationToken);
                return _ListMatSuppMstView;
            }
        }
        #endregion

        #region HarnessCostingCalculationData
        public async Task<ListHarnessCostingCalculationDataGrpc> GetHarnessCostingCalculationDataView(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(0, cancellationToken);
            if(_ListHarnessCostingCalculationDataView.HarnessCostingCalculationDataGrpc.Any())
            {
                if(takeAmount <= 0)
                {
                    return _ListHarnessCostingCalculationDataView;
                }
                
                ListHarnessCostingCalculationDataGrpc returnList = new ListHarnessCostingCalculationDataGrpc();
                IQueryable<HarnessCostingCalculationDataGrpc> query = _ListHarnessCostingCalculationDataView.HarnessCostingCalculationDataGrpc.AsQueryable().Skip(position).Take(takeAmount);
                returnList.HarnessCostingCalculationDataGrpc.AddRange(query);
                return returnList;
            }
            else
            {
                await PopulateHarnessCostingCalculationDataView(cancellationToken);
                return _ListHarnessCostingCalculationDataView;
            }
        }
        #endregion
        #endregion

        #region Data Imports
        #region MatSuppMst
        public async Task<bool> PopulateMatSuppMstView(CancellationToken cancellationToken)
        {
            if (!_MatSuppMstViewRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _MatSuppMstViewHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetMattSuppMstViewQuery, List<MatSuppMstViewGrpc>>>();
                    _MatSuppMstViewRefreshInProgress = true;
                    GetMattSuppMstViewQuery query = new GetMattSuppMstViewQuery();
                    await Task.Delay(0, cancellationToken);
                    Result<List<MatSuppMstViewGrpc>> results = await _MatSuppMstViewHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListMatSuppMstView.MatSuppMstViewGrpc.Clear();
                        _ListMatSuppMstView.MatSuppMstViewGrpc.AddRange(results.Value);
                    }

                    _MatSuppMstViewRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region HarnessCostingCalculationData
        public async Task<bool> PopulateHarnessCostingCalculationDataView(CancellationToken cancellationToken)
        {
            if (!_HarnessCostingCalculationDataViewRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _HarnessCostingCalculationDataViewHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetHarnessCostingCalculationDataViewQuery, List<HarnessCostingCalculationDataGrpc>>>();
                    _MatSuppMstViewRefreshInProgress = true;
                    GetHarnessCostingCalculationDataViewQuery query = new GetHarnessCostingCalculationDataViewQuery();
                    await Task.Delay(0, cancellationToken);
                    Result<List<HarnessCostingCalculationDataGrpc>> results = await _HarnessCostingCalculationDataViewHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListHarnessCostingCalculationDataView.HarnessCostingCalculationDataGrpc.Clear();
                        _ListHarnessCostingCalculationDataView.HarnessCostingCalculationDataGrpc.AddRange(results.Value);
                    }

                    _HarnessCostingCalculationDataViewRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #endregion

        public async Task HandleFilterCase<T>(string filterExpressionString, ParsingConfig parsingConfig,
            Action<IEnumerable<T>> setResponseCollection, CancellationToken cancellationToken)
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
                    "MATSUPPMSTVIEWGRPC" => _ListMatSuppMstView.MatSuppMstViewGrpc.Cast<T>().Where(func).ToList(),
                    _ => throw new NotSupportedException($"Filtering not supported for type {typeof(T).Name}")
                };
            }, cancellationToken);
        }

        void PopulateSampleData()
        {
            _ListMatSuppMstView = SampleCPDDataService.PopulateMatSuppMstView();
            _ListHarnessCostingCalculationDataView = SampleCPDDataService.PopulateHarnessCostingCalculationDataView();
        }
    }
}
