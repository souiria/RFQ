namespace NPR.Services
{
    public sealed class NPRAccessService : INPRAccessService
    {
        #region In Memory Datasets

        #region H1NPRView

        ListH1NPRViewGrpc _H1NPRView;

        #endregion
        #region RFQStatus

        ListRFQStatusGrpc _RFQStatus;

        #endregion
        #endregion

        #region Fields and Properties

        #region H1NPRView

        IQueryHandler<GetH1NPRViewQuery, List<H1NPRViewGrpc>>? _H1NPRViewHandler;
        bool _H1NPRViewRefreshInProgress;

        #endregion
        #region RFQStatus

        IQueryHandler<GetRFQStatusQuery, List<RFQStatusGrpc>>? _RFQStatusHandler;
        bool _RFQStatusRefreshInProgress;

        #endregion

        readonly IServiceProvider _ServiceProvider;

        #endregion

        #region Constructor

        public NPRAccessService(IServiceProvider serviceProvider, bool testing = false)
        {
            #region H1NPRView

            _H1NPRView = new ListH1NPRViewGrpc();
            _H1NPRViewRefreshInProgress = false;

            #endregion

            #region RFQStatus

            _RFQStatus = new ListRFQStatusGrpc();
            _RFQStatusRefreshInProgress = false;

            #endregion

            _ServiceProvider = serviceProvider;

            if (testing)
            {
                PopulateSampleData();
            }
        }
        #endregion

        #region Handlers

        #region H1NPRView
        public async Task<ListH1NPRViewGrpc> GetAllH1NPRView(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_H1NPRView.H1NPRViewGrpc.Any())
            {
                if(takeAmount <= 0)
                {
                    return _H1NPRView;
                }

                ListH1NPRViewGrpc returnList = new ListH1NPRViewGrpc();
                IQueryable<H1NPRViewGrpc> query = _H1NPRView.H1NPRViewGrpc.AsQueryable().Skip(position).Take(takeAmount);
                returnList.H1NPRViewGrpc.AddRange(query);
                return returnList;
            }
            else
            {
                await PopulateH1NPRViewAsync(cancellationToken);
                return _H1NPRView;
            }
        }
        #endregion

        #region RFQStatus
        public async Task<ListRFQStatusGrpc> GetAllRFQStatus(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_RFQStatus.RFQStatusGrpc.Any())
            {
                if (takeAmount <= 0)
                {
                    return _RFQStatus;
                }

                ListRFQStatusGrpc returnList = new ListRFQStatusGrpc();
                IQueryable<RFQStatusGrpc> query = _RFQStatus.RFQStatusGrpc.AsQueryable().Skip(position).Take(takeAmount);
                returnList.RFQStatusGrpc.AddRange(query);
                return returnList;
            }
            else
            {
                await PopulateRFQStatusAsync(cancellationToken);
                return _RFQStatus;
            }
        }
        #endregion
        #endregion

        #region Data Imports
        public async Task<bool> PopulateH1NPRViewAsync(CancellationToken cancellationToken)
        {
            if (!_H1NPRViewRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _H1NPRViewHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetH1NPRViewQuery, List<H1NPRViewGrpc>>>();
                    _H1NPRViewRefreshInProgress = true;
                    GetH1NPRViewQuery query = new GetH1NPRViewQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<H1NPRViewGrpc>> results = await _H1NPRViewHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _H1NPRView.H1NPRViewGrpc.Clear();
                        _H1NPRView.H1NPRViewGrpc.AddRange(results.Value);
                    }

                    _H1NPRViewRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        public async Task<bool> PopulateRFQStatusAsync(CancellationToken cancellationToken)
        {
            if (!_RFQStatusRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _RFQStatusHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetRFQStatusQuery, List<RFQStatusGrpc>>>();
                    _RFQStatusRefreshInProgress = true;
                    GetRFQStatusQuery query = new GetRFQStatusQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<RFQStatusGrpc>> results = await _RFQStatusHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _RFQStatus.RFQStatusGrpc.Clear();
                        _RFQStatus.RFQStatusGrpc.AddRange(results.Value);
                    }

                    _H1NPRViewRefreshInProgress = false;
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
                    "H1NPRVIEWGRPC" => _H1NPRView.H1NPRViewGrpc.Cast<T>().Where(func).ToList(),
                    _ => throw new NotSupportedException($"Filtering not supported for type {typeof(T).Name}")
                };
            }, cancellationToken);
        }
        void PopulateSampleData()
        {
            _H1NPRView = SampleNPRDataService.PopulateH1NPRViewGrpc();
            _RFQStatus = SampleNPRDataService.PopulateRFQStatusGrpc();
        }
    }
}
