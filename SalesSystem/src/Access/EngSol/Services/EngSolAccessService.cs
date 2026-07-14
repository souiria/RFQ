namespace EngSol.Services
{
    public class EngSolAccessService : IEngSolAccessService
    {
        #region In Memory Datasets
        #region Derivatives

        ListDerivatives _ListDerivatives;
        #endregion
        #endregion

        #region Fields and Properties

        #region DerivativeWires

        IQueryHandler<GetDerivativeWireByDerivativeIdQuery, List<DerivativeWiresGrpc>>? _DerivativeWireByIdHandler;

        #endregion

        #region DerivativeParts

        IQueryHandler<GetDerivativePartsByDerivativeIdQuery, List<DerivativePartsGrpc>>? _DerivativePartByIdHandler;

        #endregion

        #region Derivatives

        IQueryHandler<GetDerivativesQuery, List<DerivativeGrpc>>? _DerivativeHandler;
        IQueryHandler<GetDerivativeByDerivativeIdQuery, DerivativeGrpc>? _DerivativeByDerivativeIdHandler;

        bool _DerivativesRefreshInProgress;

        #endregion

        readonly IServiceProvider _ServiceProvider;
        readonly ILogger<EngSolAccessService> _Logger;
        #endregion

        #region Constructor

        public EngSolAccessService(IServiceProvider serviceProvider, ILogger<EngSolAccessService> logger, bool testing = false)
        {
            #region Derivatives

            _ListDerivatives = new ListDerivatives();
            _DerivativesRefreshInProgress = false;

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

        #region DerivativeWires

        public async Task<List<DerivativeWiresGrpc>> GetDerivativeWiresByDerivativeId(int derivativeId, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            List<DerivativeWiresGrpc> reuturnWireList = new List<DerivativeWiresGrpc>();
            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                _DerivativeWireByIdHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDerivativeWireByDerivativeIdQuery, List<DerivativeWiresGrpc>>>();
                GetDerivativeWireByDerivativeIdQuery query = new GetDerivativeWireByDerivativeIdQuery();
                query.Id = derivativeId;
                Result<List<DerivativeWiresGrpc>> results = await _DerivativeWireByIdHandler.Handle(query, cancellationToken);
                if (0 < results.Value.Count)
                {
                    reuturnWireList = results.Value.Where(x => x.DerivativeID == derivativeId).ToList() ?? new List<DerivativeWiresGrpc>();
                }

                return reuturnWireList;
            }
        }

        #endregion

        #region DerivativeParts
        public async Task<List<DerivativePartsGrpc>> GetDerivativePartsByDerivativeId(int derivativeId, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            List<DerivativePartsGrpc> reuturnPartList = new List<DerivativePartsGrpc>();
            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                _DerivativePartByIdHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDerivativePartsByDerivativeIdQuery, List<DerivativePartsGrpc>>>();
                GetDerivativePartsByDerivativeIdQuery query = new GetDerivativePartsByDerivativeIdQuery();
                query.Id = derivativeId;
                Result<List<DerivativePartsGrpc>> results = await _DerivativePartByIdHandler.Handle(query, cancellationToken);
                if (0 < results.Value.Count)
                {
                    reuturnPartList = results.Value.Where(x => x.DerivativeID == derivativeId).ToList() ?? new List<DerivativePartsGrpc>();
                }

                return reuturnPartList;
            }
        }

        #endregion

        #region Derivatives

        public async Task<ListDerivatives> GetAllDerivatives(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListDerivatives.DerivativeGrpc.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListDerivatives;
                }

                ListDerivatives returnList = new ListDerivatives();
                IQueryable<DerivativeGrpc> query = _ListDerivatives.DerivativeGrpc.AsQueryable().Skip(position).Take(takeAmount);
                returnList.DerivativeGrpc.AddRange(query);
                return returnList;
            }
            else
            {
                await PopulateDerivativesAsync(cancellationToken);
                return _ListDerivatives;
            }
        }

        public async Task<DerivativeGrpc> GetDerivativeByDerivativeId(int derivativeId, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            DerivativeGrpc returnDerivative = new DerivativeGrpc();
            returnDerivative = _ListDerivatives.DerivativeGrpc.FirstOrDefault(x => x.DerivativeID == derivativeId) ?? new DerivativeGrpc();
            if (returnDerivative.DerivativeID != null)
            {
                return returnDerivative;
            }
            else
            {
                
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _DerivativeByDerivativeIdHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDerivativeByDerivativeIdQuery, DerivativeGrpc>>();
                    GetDerivativeByDerivativeIdQuery query = new GetDerivativeByDerivativeIdQuery();
                    query.Id = derivativeId;
                    Result<DerivativeGrpc> results = await _DerivativeByDerivativeIdHandler.Handle(query, cancellationToken);
                    if (results.Value != null)
                    {
                        returnDerivative = results.Value ?? new DerivativeGrpc();
                    }

                    return returnDerivative;
                }
            }
        }

        #endregion

        #endregion

        #region Data Imports

        #region Derivatives
        public async Task<bool> PopulateDerivativesAsync(CancellationToken cancellationToken)
        {
            if (!_DerivativesRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _DerivativeHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDerivativesQuery, List<DerivativeGrpc>>>();
                    _DerivativesRefreshInProgress = true;
                    GetDerivativesQuery query = new GetDerivativesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<DerivativeGrpc>> results = await _DerivativeHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListDerivatives.DerivativeGrpc.Clear();
                        _ListDerivatives.DerivativeGrpc.AddRange(results.Value);
                    }

                    _DerivativesRefreshInProgress = false;
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
                    "DERIVATIVEGRPC" => _ListDerivatives.DerivativeGrpc.Cast<T>().Where(func).ToList(),
                    _ => throw new NotSupportedException($"Filtering not supported for type {typeof(T).Name}")
                };
            }, cancellationToken);
        }

        void PopulateSampleData()
        {
            _ListDerivatives = SampleEngSolDataService.PopulateDerivatives();
        }
    }
}
