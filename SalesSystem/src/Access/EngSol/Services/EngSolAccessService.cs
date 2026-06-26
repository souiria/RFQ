namespace EngSol.Services
{
    public class EngSolAccessService : IEngSolAccessService
    {
        #region In Memory Datasets

        #region DerivativeWires

        ListDerivativeWiresGrpc _ListDerivativeWires;

        #endregion
        #endregion

        #region Fields and Properties

        #region DerivativeWires

        IQueryHandler<GetDerivativeWiresQuery, List<DerivativeWiresGrpc>>? _DerivativeWiresHandler;
        IQueryHandler<GetDerivativeWireByIdQuery, List<DerivativeWiresGrpc>>? _DerivativeWireByIdHandler;
        bool _DerivativeWiresRefreshInProgress;

        #endregion

        readonly IServiceProvider _ServiceProvider;
        readonly ILogger<EngSolAccessService> _Logger;
        #endregion

        #region Constructor

        public EngSolAccessService(IServiceProvider serviceProvider, ILogger<EngSolAccessService> logger, bool testing = false)
        {
            #region DerivativeWires

            _ListDerivativeWires = new ListDerivativeWiresGrpc();
            _DerivativeWiresRefreshInProgress = false;

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

        public async Task<ListDerivativeWiresGrpc> GetAllDerivativeWires(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListDerivativeWires.DerivativeWiresGrpc.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListDerivativeWires;
                }

                ListDerivativeWiresGrpc returnList = new ListDerivativeWiresGrpc();
                IQueryable<DerivativeWiresGrpc> query = _ListDerivativeWires.DerivativeWiresGrpc.AsQueryable().Skip(position).Take(takeAmount);
                returnList.DerivativeWiresGrpc.AddRange(query);
                return returnList;
            }
            else
            {
                await PopulateDerivativeWiresAsync(cancellationToken);
                return _ListDerivativeWires;
            }
        }

        public async Task<DerivativeWiresGrpc> GetDerivativeWireById(int derivativeId, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            DerivativeWiresGrpc reuturnWire = new DerivativeWiresGrpc();
            if (_ListDerivativeWires.DerivativeWiresGrpc.Any())
            {
                DerivativeWiresGrpc? wire = _ListDerivativeWires.DerivativeWiresGrpc.FirstOrDefault(x => x.DerivativeID == derivativeId);
                if (wire != null)
                {
                    using (IServiceScope scope = _ServiceProvider.CreateScope())
                    {
                        _DerivativeWireByIdHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDerivativeWireByIdQuery, List<DerivativeWiresGrpc>>>();
                        GetDerivativeWireByIdQuery query = new GetDerivativeWireByIdQuery();
                        query.Id = derivativeId;
                        Result<List<DerivativeWiresGrpc>> results = await _DerivativeWireByIdHandler.Handle(query, cancellationToken);
                        if (0 < results.Value.Count)
                        {
                            reuturnWire = results.Value.FirstOrDefault(x => x.DerivativeID == derivativeId) ?? new DerivativeWiresGrpc();
                        }
                    }
                }

                return reuturnWire;
            }
            else
            {
                await PopulateDerivativeWiresAsync(cancellationToken);
                return reuturnWire;
            }
        }

        

        #endregion

        #endregion

        #region Data Imports

        #region DerivativeWires
        public async Task<bool> PopulateDerivativeWiresAsync(CancellationToken cancellationToken)
        {
            if (!_DerivativeWiresRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _DerivativeWiresHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDerivativeWiresQuery, List<DerivativeWiresGrpc>>>();
                    _DerivativeWiresRefreshInProgress = true;
                    GetDerivativeWiresQuery query = new GetDerivativeWiresQuery();
                    query.Position = 0;
                    query.TakeAmount = 1000;
                    await Task.Delay(1, cancellationToken);
                    Result<List<DerivativeWiresGrpc>> results = await _DerivativeWiresHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListDerivativeWires.DerivativeWiresGrpc.Clear();
                        _ListDerivativeWires.DerivativeWiresGrpc.AddRange(results.Value);
                    }

                    _DerivativeWiresRefreshInProgress = false;
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
                    "DERIVATIVEWIRESGRPC" => _ListDerivativeWires.DerivativeWiresGrpc.Cast<T>().Where(func).ToList(),
                    _ => throw new NotSupportedException($"Filtering not supported for type {typeof(T).Name}")
                };
            }, cancellationToken);
        }

        void PopulateSampleData()
        {
        }
    }
}
