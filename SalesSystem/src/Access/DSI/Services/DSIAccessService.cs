namespace DSI.Services
{
    public partial class DSIAccessService : IDSIAccessService
    {
        ILogger<DSIAccessService> _Logger;

        #region In Memory Datasets

        #region Component
        ListComponentGrpc _ListComponentGrpc;
     
        #endregion

        #region BranchInsulation
        ListBranchInsulationGrpc _ListBranchInsulationGrpc;
        #endregion

        #region WireSpecification
        ListWireSpecificationGrpc _ListWireSpecificationGrpc;
        #endregion

        #region CompositeDetail
        ListCompositeDetailGrpc _ListCompositeDetailGrpc;
        #endregion

        #region Harness
        ListHarnessGrpc _ListHarnessGrpc;
        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////
        #endregion

        #region Fields and Properties

         #region Component
        IQueryHandler<GetComponentQuery, List<ComponentGrpc>>? _ComponentHandler;
        bool _ComponentRefreshInProgress;
        #endregion

        #region BranchInsulation
        IQueryHandler<GetBranchInsulationQuery, List<BranchInsulationGrpc>>? _BranchHandler;
        bool _BranchRefreshInProgress;
        #endregion

        #region WireSpecification
        IQueryHandler<GetWireSpecificationQuery, List<WireSpecificationGrpc>>? _WireHandler;
        bool _WireRefreshInProgress;
        #endregion

        #region CompositeDetail
        IQueryHandler<GetCompositeDetailQuery, List<CompositeDetailGrpc>>? _CompositeHandler;
        bool _CompositeRefreshInProgress;
        #endregion

        #region Harness
        IQueryHandler<GetHarnessQuery, List<HarnessGrpc>>? _HarnessHandler;
        bool _HarnessRefreshInProgress;
        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////

        readonly IServiceProvider _ServiceProvider;

        #endregion

        #region Constructor
        public DSIAccessService(IServiceProvider serviceProvider,
                                ILogger<DSIAccessService> logger,
                                bool testing = false)
        {
            _ListComponentGrpc = new();
            _ComponentRefreshInProgress = false;

            _ListBranchInsulationGrpc = new();
            _BranchRefreshInProgress = false;

            _ListWireSpecificationGrpc = new();
            _WireRefreshInProgress = false;

            _ListCompositeDetailGrpc = new();
            _CompositeRefreshInProgress = false;

            _ListHarnessGrpc = new();
            _HarnessRefreshInProgress = false;

            _ServiceProvider = serviceProvider;
            _Logger = logger;

            if (testing)
            {
                PopulateSampleData();
            }
        }
        #endregion

        #region Handlers

        public async Task<ListComponentGrpc> GetAllComponent(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);

            if (_ListComponentGrpc.ComponentList.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListComponentGrpc;
                }

                ListComponentGrpc returnList = new ListComponentGrpc();
                IEnumerable<ComponentGrpc> query = _ListComponentGrpc.ComponentList.Skip(position).Take(takeAmount);
                returnList.ComponentList.AddRange(query);
                return returnList;
            }
            else
            {
                await PopulateComponent(cancellationToken);
                return _ListComponentGrpc;
            }
        }

        public async Task<ListBranchInsulationGrpc> GetAllBranchInsulation(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);

            if (_ListBranchInsulationGrpc.BranchInsulationList.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListBranchInsulationGrpc;
                }

                ListBranchInsulationGrpc returnList = new ListBranchInsulationGrpc();
                IEnumerable<BranchInsulationGrpc> query =
                    _ListBranchInsulationGrpc.BranchInsulationList.Skip(position).Take(takeAmount);

                returnList.BranchInsulationList.AddRange(query);
                return returnList;
            }
            else
            {
                await PopulateBranchInsulation(cancellationToken);
                return _ListBranchInsulationGrpc;
            }
        }
        public async Task<ListWireSpecificationGrpc> GetAllWireSpecification(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);

            if (_ListWireSpecificationGrpc.WireSpecificationList.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListWireSpecificationGrpc;
                }

                ListWireSpecificationGrpc returnList = new ListWireSpecificationGrpc();
                IEnumerable<WireSpecificationGrpc> query =
                    _ListWireSpecificationGrpc.WireSpecificationList.Skip(position).Take(takeAmount);

                returnList.WireSpecificationList.AddRange(query);
                return returnList;
            }
            else
            {
                await PopulateWireSpecification(cancellationToken);
                return _ListWireSpecificationGrpc;
            }
        }

        public async Task<ListHarnessGrpc> GetAllHarness(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);

            if (_ListHarnessGrpc.HarnessList.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListHarnessGrpc;
                }

                ListHarnessGrpc returnList = new ListHarnessGrpc();
                IEnumerable<HarnessGrpc> query =
                    _ListHarnessGrpc.HarnessList.Skip(position).Take(takeAmount);

                returnList.HarnessList.AddRange(query);
                return returnList;
            }
            else
            {
                await PopulateHarness(cancellationToken);
                return _ListHarnessGrpc;
            }
        }
        public async Task<ListCompositeDetailGrpc> GetAllCompositeDetail(
             CancellationToken cancellationToken,
             int position = 0,
             int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);

            if (_ListCompositeDetailGrpc.CompositeDetailList.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListCompositeDetailGrpc;
                }

                ListCompositeDetailGrpc returnList = new ListCompositeDetailGrpc();

                IEnumerable<CompositeDetailGrpc> query =
                    _ListCompositeDetailGrpc.CompositeDetailList
                    .Skip(position)
                    .Take(takeAmount);

                returnList.CompositeDetailList.AddRange(query);

                return returnList;
            }
            else
            {
                await PopulateCompositeDetail(cancellationToken);
                return _ListCompositeDetailGrpc;
            }
        }
        #endregion

        #region Data Imports

        public async Task<bool> PopulateComponent(CancellationToken cancellationToken)
        {
            if (!_ComponentRefreshInProgress)
            {
                using IServiceScope scope = _ServiceProvider.CreateScope();

                _ComponentHandler = scope.ServiceProvider
                    .GetRequiredService<IQueryHandler<GetComponentQuery, List<ComponentGrpc>>>();

                _ComponentRefreshInProgress = true;

                GetComponentQuery query = new();

                await Task.Delay(1, cancellationToken);

                Result<List<ComponentGrpc>> results = await _ComponentHandler.Handle(query, cancellationToken);

                if (results.Value.Count <= 0)
                {

                }
                else
                {
                    _ListComponentGrpc.ComponentList.Clear();
                    _ListComponentGrpc.ComponentList.AddRange(results.Value);
                }

                _ComponentRefreshInProgress = false;
            }

            return true;
        }
        public async Task<bool> PopulateBranchInsulation(CancellationToken cancellationToken)
        {
            if (!_BranchRefreshInProgress)
            {
                using IServiceScope scope = _ServiceProvider.CreateScope();

                _BranchHandler = scope.ServiceProvider
                    .GetRequiredService<IQueryHandler<GetBranchInsulationQuery, List<BranchInsulationGrpc>>>();

                _BranchRefreshInProgress = true;

                GetBranchInsulationQuery query = new();

                await Task.Delay(1, cancellationToken);

                Result<List<BranchInsulationGrpc>> results =
                    await _BranchHandler.Handle(query, cancellationToken);

                if (results.Value.Count <= 0)
                {
                }
                else
                {
                    _ListBranchInsulationGrpc.BranchInsulationList.Clear();
                    _ListBranchInsulationGrpc.BranchInsulationList.AddRange(results.Value);
                }

                _BranchRefreshInProgress = false;
            }

            return true;
        }
        public async Task<bool> PopulateWireSpecification(CancellationToken cancellationToken)
        {
            if (!_WireRefreshInProgress)
            {
                using IServiceScope scope = _ServiceProvider.CreateScope();

                _WireHandler = scope.ServiceProvider
                    .GetRequiredService<IQueryHandler<GetWireSpecificationQuery, List<WireSpecificationGrpc>>>();

                _WireRefreshInProgress = true;

                GetWireSpecificationQuery query = new();

                await Task.Delay(1, cancellationToken);

                Result<List<WireSpecificationGrpc>> results =
                    await _WireHandler.Handle(query, cancellationToken);

                if (results.Value.Count <= 0)
                {
         
                }else
                {
                    _ListWireSpecificationGrpc.WireSpecificationList.Clear();
                    _ListWireSpecificationGrpc.WireSpecificationList.AddRange(results.Value);
                }

                _WireRefreshInProgress = false;
            }

            return true;
        }
        public async Task<bool> PopulateCompositeDetail(CancellationToken cancellationToken)
        {
            if (!_CompositeRefreshInProgress)
            {
                using IServiceScope scope = _ServiceProvider.CreateScope();

                _CompositeHandler = scope.ServiceProvider
                    .GetRequiredService<IQueryHandler<GetCompositeDetailQuery, List<CompositeDetailGrpc>>>();

                _CompositeRefreshInProgress = true;

                GetCompositeDetailQuery query = new();

                await Task.Delay(1, cancellationToken);

                Result<List<CompositeDetailGrpc>> results =
                    await _CompositeHandler.Handle(query, cancellationToken);

                if (results.Value.Count <=0)
                {
       
                }
                else
                {
                    _ListCompositeDetailGrpc.CompositeDetailList.Clear();
                    _ListCompositeDetailGrpc.CompositeDetailList.AddRange(results.Value);
                }

                _CompositeRefreshInProgress = false;
            }

            return true;
        }
        public async Task<bool> PopulateHarness(CancellationToken cancellationToken)
        {
            if (!_HarnessRefreshInProgress)
            {
                using IServiceScope scope = _ServiceProvider.CreateScope();

                _HarnessHandler = scope.ServiceProvider
                    .GetRequiredService<IQueryHandler<GetHarnessQuery, List<HarnessGrpc>>>();

                _HarnessRefreshInProgress = true;

                GetHarnessQuery query = new();

                await Task.Delay(1, cancellationToken);

                Result<List<HarnessGrpc>> results =
                    await _HarnessHandler.Handle(query, cancellationToken);

                if (results.Value.Count <= 0)
                {

                }
                else
                {
                    _ListHarnessGrpc.HarnessList.Clear();
                    _ListHarnessGrpc.HarnessList.AddRange(results.Value);
                }

                _HarnessRefreshInProgress = false;
            }

            return true;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////
        #endregion

        public async Task HandleFilterCase<T>(string filterExpressionString, ParsingConfig parsingConfig, Action<IEnumerable<T>> setResponseCollection,
        CancellationToken cancellationToken)
        {
            _Logger.GenericLogInformation($"III DSIAccessService.HandleFilterCase - Starting");
            _Logger.GenericLogInformation($"III DSIAccessService.HandleFilterCase filterExpressionString : - {filterExpressionString}");
            Expression<Func<T, bool>> filterExpression = DynamicExpressionParser.ParseLambda<T, bool>(parsingConfig, false, filterExpressionString);
            Func<T, bool> compiledExpression = filterExpression.Compile();
            IEnumerable<T> filteredList = new List<T>();
            filteredList = await Filter(compiledExpression, cancellationToken);
            setResponseCollection(filteredList);
            _Logger.GenericLogInformation($"III DSIAccessService.HandleFilterCase filteredList count : - {filteredList.Count()}");
        }

        public async Task<IEnumerable<T>> Filter<T>(Func<T, bool> func, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                _Logger.GenericLogInformation($"III DSIAccessService.Filter - Starting");
                return typeof(T).Name.ToUpperInvariant() switch
                {
                    "COMPONENTGRPC" => _ListComponentGrpc.ComponentList.Cast<T>().Where(func).ToList(),
                    "BRANCHINSULATIONGRPC" => _ListBranchInsulationGrpc.BranchInsulationList.Cast<T>().Where(func).ToList(),
                    "WIRESPECIFICATIONGRPC" => _ListWireSpecificationGrpc.WireSpecificationList.Cast<T>().Where(func).ToList(),
                    "COMPOSITEDETAILGRPC" => _ListCompositeDetailGrpc.CompositeDetailList.Cast<T>().Where(func).ToList(),
                    "HARNESSGRPC" => _ListHarnessGrpc.HarnessList.Cast<T>().Where(func).ToList(),

                    _ => throw new NotSupportedException($"Filtering not supported for type {typeof(T).Name}")
                };
            }, cancellationToken);
        }
        void PopulateSampleData()
        {
            _ListComponentGrpc = SampleDSIDataService.PopulateComponentGrpc();
            _ListBranchInsulationGrpc = SampleDSIDataService.PopulateBranchInsulationGrpc();
            _ListWireSpecificationGrpc = SampleDSIDataService.PopulateWireSpecificationGrpc();
            _ListCompositeDetailGrpc = SampleDSIDataService.PopulateCompositeDetailGrpc();
            _ListHarnessGrpc = SampleDSIDataService.PopulateHarnessGrpc();



        }
    }
}
