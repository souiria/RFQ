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
        #region CompositeDetailByHarnessName
        public async Task<ListCompositeDetailGrpc> GetCompositeDetailByHarnessName(
    string harnessName,
    CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            ListCompositeDetailGrpc response = new ListCompositeDetailGrpc();

            //////////////////////////////////////////////////////
            // ✅ STEP 1: Ensure Harness cache is loaded
            //////////////////////////////////////////////////////
            if (!_ListHarnessGrpc.HarnessList.Any())
            {
                await PopulateHarness(cancellationToken);
            }

            //////////////////////////////////////////////////////
            // ✅ STEP 2: Find Harness by name
            //////////////////////////////////////////////////////
            HarnessGrpc? harness = _ListHarnessGrpc.HarnessList
                .FirstOrDefault(h => h.HarnessName1 == harnessName);

            if (harness == null)
            {
                _Logger.GenericLogInformation(
                    $"No Harness found with name {harnessName}");

                return response; // empty
            }

            //////////////////////////////////////////////////////
            // ✅ STEP 3: Get Harness ID
            //////////////////////////////////////////////////////
            string? harnessId = harness.Id;

            if (string.IsNullOrEmpty(harnessId))
            {
                return response;
            }

            //////////////////////////////////////////////////////
            // ✅ STEP 4: Ensure CompositeDetail cache is loaded
            //////////////////////////////////////////////////////
            if (!_ListCompositeDetailGrpc.CompositeDetailList.Any())
            {
                await PopulateCompositeDetail(cancellationToken);
            }

            //////////////////////////////////////////////////////
            // ✅ STEP 5: Filter CompositeDetail by HarnessID
            //////////////////////////////////////////////////////
            IEnumerable<CompositeDetailGrpc> filtered =
                _ListCompositeDetailGrpc.CompositeDetailList
                .Where(x => x.HarnessID == harnessId);

            response.CompositeDetailList.AddRange(filtered);

            return response;
        }

        #endregion
        #region ComponentsByHarnessNameAndOptions
        #region ComponentsByHarnessNameAndOptions

        #region ComponentsByHarnessNameAndOptions

        public async Task<ListComponentGrpc> GetComponentsByHarnessAndOptions(
            IEnumerable<string> harnessNames,
            IEnumerable<string> compositeOptions,
            CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            ListComponentGrpc response = new ListComponentGrpc();

            //////////////////////////////////////////////////////
            // STEP 1: Load Harness cache
            //////////////////////////////////////////////////////
            if (!_ListHarnessGrpc.HarnessList.Any())
            {
                await PopulateHarness(cancellationToken);
            }

            //////////////////////////////////////////////////////
            // STEP 2: Normalize Harness Names
            //////////////////////////////////////////////////////
            List<string> harnessNameList = new List<string>();

            if (harnessNames != null)
            {
                harnessNameList = harnessNames
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Select(x => x.Trim())
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .ToList();
            }

            if (!harnessNameList.Any())
            {
                return response;
            }

            //////////////////////////////////////////////////////
            // STEP 3: Resolve Harness IDs
            //////////////////////////////////////////////////////
            HashSet<string> harnessIds = _ListHarnessGrpc.HarnessList
                .Where(h => !string.IsNullOrWhiteSpace(h.HarnessName1)
                            && !string.IsNullOrWhiteSpace(h.Id)
                            && harnessNameList.Contains(h.HarnessName1, StringComparer.OrdinalIgnoreCase))
                .Select(h => h.Id!)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            if (!harnessIds.Any())
            {
                return response;
            }

            //////////////////////////////////////////////////////
            // STEP 4: Load CompositeDetail cache
            //////////////////////////////////////////////////////
            if (!_ListCompositeDetailGrpc.CompositeDetailList.Any())
            {
                await PopulateCompositeDetail(cancellationToken);
            }

            List<CompositeDetailGrpc> compositeList = _ListCompositeDetailGrpc.CompositeDetailList
                .Where(c => !string.IsNullOrWhiteSpace(c.HarnessID)
                            && harnessIds.Contains(c.HarnessID))
                .ToList();

            if (!compositeList.Any())
            {
                return response;
            }

            //////////////////////////////////////////////////////
            // STEP 5: Normalize CompositeOptions
            //////////////////////////////////////////////////////
            List<string> options = new List<string>();

            if (compositeOptions != null && compositeOptions.Any())
            {
                options = compositeOptions
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .SelectMany(x => x.Split(',', StringSplitOptions.RemoveEmptyEntries))
                    .Select(x => x.Trim())
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .ToList();
            }
            else
            {
                options = compositeList
                    .Where(c => !string.IsNullOrWhiteSpace(c.CircuitOption))
                    .SelectMany(c => c.CircuitOption!.Split(',', StringSplitOptions.RemoveEmptyEntries))
                    .Select(x => x.Trim())
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .ToList();
            }

            if (!options.Any())
            {
                return response;
            }

            //////////////////////////////////////////////////////
            // STEP 6: Load WireSpecification cache
            //////////////////////////////////////////////////////
            if (!_ListWireSpecificationGrpc.WireSpecificationList.Any())
            {
                await PopulateWireSpecification(cancellationToken);
            }

            List<WireSpecificationGrpc> wires = _ListWireSpecificationGrpc.WireSpecificationList
                .Where(w => !string.IsNullOrWhiteSpace(w.Compositeoptionstring)
                            && !string.IsNullOrWhiteSpace(w.HarnessID)
                            && harnessIds.Contains(w.HarnessID)
                            && options.Contains(w.Compositeoptionstring, StringComparer.OrdinalIgnoreCase))
                .ToList();

            if (!wires.Any())
            {
                return response;
            }

            //////////////////////////////////////////////////////
            // STEP 7: Collect NodeNames
            //////////////////////////////////////////////////////
            HashSet<string> nodeNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (WireSpecificationGrpc? w in wires)
            {
                if (!string.IsNullOrWhiteSpace(w.End1NodeName))
                {
                    nodeNames.Add(w.End1NodeName);
                }

                if (!string.IsNullOrWhiteSpace(w.End2NodeName))
                {
                    nodeNames.Add(w.End2NodeName);
                }
            }

            if (!nodeNames.Any())
            {
                return response;
            }

            //////////////////////////////////////////////////////
            // STEP 8: Load Component cache
            //////////////////////////////////////////////////////
            if (!_ListComponentGrpc.ComponentList.Any())
            {
                await PopulateComponent(cancellationToken);
            }

            //////////////////////////////////////////////////////
            // STEP 9: Filter Components + Group
            //////////////////////////////////////////////////////
            List<ComponentGrpc> groupedComponents = _ListComponentGrpc.ComponentList
                .Where(c => !string.IsNullOrWhiteSpace(c.NodeName)
                            && !string.IsNullOrWhiteSpace(c.HarnessID)
                            && harnessIds.Contains(c.HarnessID)
                            && nodeNames.Contains(c.NodeName))
                .GroupBy(c => new
                {
                    c.PartNumber1,
                    c.PartNumber2,
                    c.PartNumber3
                })
                .Select(group =>
                {
                    ComponentGrpc item = new ComponentGrpc();

                    if (!string.IsNullOrWhiteSpace(group.Key.PartNumber1))
                    {
                        item.PartNumber1 = group.Key.PartNumber1;
                    }

                    if (!string.IsNullOrWhiteSpace(group.Key.PartNumber2))
                    {
                        item.PartNumber2 = group.Key.PartNumber2;
                    }

                    if (!string.IsNullOrWhiteSpace(group.Key.PartNumber3))
                    {
                        item.PartNumber3 = group.Key.PartNumber3;
                    }

                    double total = group.Sum(x => x.Quantity ?? 0);
                    item.Quantity = total;

                    return item;
                })
                .ToList();

            response.ComponentList.AddRange(groupedComponents);

            //////////////////////////////////////////////////////
            // OPTIONAL: include joined harness names in response
            //////////////////////////////////////////////////////
            response.HarnessName = string.Join(",", harnessNameList);

            return response;
        }

        #endregion

        #endregion

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
