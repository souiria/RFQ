namespace Master.Services
{
    /// <summary>
    /// This class is used to make calls to the database queries and to hold the data dictionaries.
    /// It is used by both the Grpc and Http api services
    /// </summary>
    public sealed class MasterAccessService : IMasterAccessService
    {
        #region In Memory Datasets

        #region Currency

        ListCurrencyGrpc _Currencies;
        ListCurrencyGrpc _FilteredCurrencies;

        #endregion

        #region Customer

        ListCustomerGrpc _Customers;
        ListCustomerGrpc _FilteredCustomers;
        ListCustomerLocationGrpc _CustomerLocations;
        ListCustomerLocationGrpc _FilteredLocations;
        ListCustomerSalesEntityGrpc _CustomerSalesEntities;
        ListCustomerSalesEntityGrpc _FilteredCustomerSalesEntities;
        ListCustomerProjectAssociationGrpc _CustomerProjectAssociations;
        ListCustomerProjectAssociationGrpc _FilteredCustomerProjectAssociations;
        ListCustomerBusinessUserAssociationGrpc _CustomerBusinessUserAssociations;
        ListCustomerBusinessUserAssociationGrpc _FilteredCustomerBusinessUserAssociations;

        #endregion

        #region Project

        ListPlatformGrpc _Platforms;
        ListPlatformGrpc _FilteredPlatforms;
        ListProgramGrpc _Programs;
        ListProgramGrpc _FilteredPrograms;
        ListProjectGrpc _Projects;
        ListProjectGrpc _FilteredProjects;
        ListMilestoneGrpc _Milestones;
        ListMilestoneGrpc _FilteredMilestones;

        #endregion

        #region Vehicle

        ListVehicleGrpc _Vehicles;
        ListVehicleGrpc _FilteredVehicles;

        #endregion

        #region SupplierGroup

        ListSupplierGroupGrpc _SupplierGroups;
        ListSupplierGroupGrpc _FilteredSupplierGroups;

        #endregion

        #region SupplierGroup

        ListSupplierGrpc _Suppliers;
        ListSupplierGrpc _FilteredSuppliers;

        #endregion

        #region ProjectEngineerAssociation

        ListProjectEngineeringAssociationGrpc _ProjectEngineeringAssociations;
        #endregion

        #endregion

        #region Fields and Properties

        #region Currency

        IQueryHandler<GetCurrenciesQuery, List<CurrencyGrpc>>? _CurrencyHandler;
        bool _CurrencyRefreshInProgress;

        #endregion

        #region Customer

        IQueryHandler<GetAllCustomerBusinessUnitsQuery, List<CustomerGrpc>>? _CustomerHandler;
        IQueryHandler<GetAllCustomerLocationsQuery, List<CustomerLocationGrpc>>? _CustomerLocationHandler;
        IQueryHandler<GetAllCustomerProjectAssociationsQuery, List<CustomerProjectAssociationGrpc>>? _CustomerProjectAssociationsHandler;
        IQueryHandler<GetAllCustomerSalesEntitiesQuery, List<CustomerSalesEntityGrpc>>? _CustomerSalesEntitiesHandler;
        IQueryHandler<GetCustomerBusinessUserAssociationsQuery, List<CustomerBusinessUserAssociationGrpc>>? _CustomerBusinessUserAssociationsHandler;
        bool _CustomerRefreshInProgress;
        bool _CustomerLocationRefreshInProgress;
        bool _CustomerProjectAssociationsRefreshInProgress;
        bool _CustomerSalesEntitiesRefreshInProgress;
        bool _CustomerBusinessUserAssociationsRefreshInProgress;

        #endregion

        #region Project

        IQueryHandler<GetAllPlatformHierarchiesQuery, List<PlatformGrpc>>? _PlatformHandler;
        IQueryHandler<GetAllProgramHierarchiesQuery, List<ProgramGrpc>>? _ProgramHandler;
        IQueryHandler<GetAllProjectHierarchiesQuery, List<ProjectGrpc>>? _ProjectHandler;
        IQueryHandler<GetAllMilestoneHierarchiesQuery, List<MilestoneGrpc>>? _MilestoneHandler;
        bool _PlatformRefreshInProgress;
        bool _ProgramRefreshInProgress;
        bool _ProjectRefreshInProgress;
        bool _MilestoneRefreshInProgress;

        #endregion

        #region Vehicle

        IQueryHandler<GetAllVehiclesQuery, List<VehicleGrpc>>? _VehicleHandler;
        bool _VehicleRefreshInProgress;

        #endregion

        #region SupplierGroup

        IQueryHandler<GetAllSupplierGroupsQuery, List<SupplierGroupGrpc>>? _SupplierGroupHandler;
        bool _SupplierGroupRefreshInProgress;

        #endregion

        #region SupplierGroup

        IQueryHandler<GetAllSuppliersQuery, List<SupplierGrpc>>? _SupplierHandler;
        bool _SupplierRefreshInProgress;

        #endregion

        #region ProjectEngineerAssociation

        IQueryHandler<GetAllProjectEngineeringAssociationQuery, List<ProjectEngineeringAssociationGrpc>>? _ProjectEngineeringAssociationHandler;
        bool _ProjectEngineeringAssociationRefreshInProgress;
        #endregion

        readonly IServiceProvider _ServiceProvider;

        #endregion

        #region Constructor
        public MasterAccessService(IServiceProvider serviceProvider, bool testing = false)
        {

            #region Currency

            _Currencies = new ListCurrencyGrpc();
            _FilteredCurrencies = new ListCurrencyGrpc();
            _CurrencyRefreshInProgress = false;

            #endregion

            #region Customer

            _Customers = new ListCustomerGrpc();
            _FilteredCustomers = new ListCustomerGrpc();
            _CustomerLocations = new ListCustomerLocationGrpc();
            _FilteredLocations = new ListCustomerLocationGrpc();
            _CustomerSalesEntities = new ListCustomerSalesEntityGrpc();
            _FilteredCustomerSalesEntities = new ListCustomerSalesEntityGrpc();
            _CustomerProjectAssociations = new ListCustomerProjectAssociationGrpc();
            _FilteredCustomerProjectAssociations = new ListCustomerProjectAssociationGrpc();
            _CustomerBusinessUserAssociations = new ListCustomerBusinessUserAssociationGrpc();
            _FilteredCustomerBusinessUserAssociations = new ListCustomerBusinessUserAssociationGrpc();
            _CustomerRefreshInProgress = false;
            _CustomerLocationRefreshInProgress = false;
            _CustomerProjectAssociationsRefreshInProgress = false;
            _CustomerSalesEntitiesRefreshInProgress = false;
            _CustomerBusinessUserAssociationsRefreshInProgress = false;

            #endregion

            #region Project

            _Platforms = new ListPlatformGrpc();
            _FilteredPlatforms = new ListPlatformGrpc();
            _Programs = new ListProgramGrpc();
            _FilteredPrograms = new ListProgramGrpc();
            _Projects = new ListProjectGrpc();
            _FilteredProjects = new ListProjectGrpc();
            _Milestones = new ListMilestoneGrpc();
            _FilteredMilestones = new ListMilestoneGrpc();

            _PlatformRefreshInProgress = false;
            _ProgramRefreshInProgress = false;
            _ProjectRefreshInProgress = false;
            _MilestoneRefreshInProgress = false;

            #endregion

            #region Vehicle

            _Vehicles = new ListVehicleGrpc();
            _FilteredVehicles = new ListVehicleGrpc();
            _VehicleRefreshInProgress = false;

            #endregion

            #region SupplierGroup

            _SupplierGroups = new ListSupplierGroupGrpc();
            _FilteredSupplierGroups = new ListSupplierGroupGrpc();
            _SupplierGroupRefreshInProgress = false;

            #endregion

            #region Supplier

            _Suppliers = new ListSupplierGrpc();
            _FilteredSuppliers = new ListSupplierGrpc();
            _SupplierRefreshInProgress = false;

            #endregion

            #region ProjectEngineerAssociation

            _ProjectEngineeringAssociations = new ListProjectEngineeringAssociationGrpc();
            _ProjectEngineeringAssociationRefreshInProgress = false;

            #endregion

            _ServiceProvider = serviceProvider;

            if (testing)
            {
                PopulateSampleData();
            }
        }
        #endregion

        #region Handlers

        #region Currency

        public async Task<ListCurrencyGrpc> GetAllCurrencies(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_Currencies.CurrencyGrpc.Any())
            {
                if(takeAmount <= 0)
                {
                    return _Currencies;
                }

                ListCurrencyGrpc returnList = new ListCurrencyGrpc();
                IQueryable<CurrencyGrpc> query = _Currencies.CurrencyGrpc.AsQueryable().Skip(position).Take(takeAmount);
                returnList.CurrencyGrpc.AddRange(query);
                return returnList;
            }
            else
            {
                await PopulateCurrenciesAsync(cancellationToken);
                return _Currencies;
            }
        }

        #endregion

        #region Customer

        public async Task<ListCustomerGrpc> GetAllCustomerBusinessUnits(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_Customers.CustomerGrpc.Any())
            {
                if (takeAmount <= 0)
                {
                    return _Customers;
                }

                ListCustomerGrpc returnList = new ListCustomerGrpc();
                IQueryable<CustomerGrpc> query = _Customers.CustomerGrpc.AsQueryable().Skip(position).Take(takeAmount);
                returnList.CustomerGrpc.AddRange(query);
                return returnList;
            }
            else
            {
                await PopulateCustomersAsync(cancellationToken);
                return _Customers;
            }
        }

        public async Task<ListCustomerLocationGrpc> GetAllCustomerLocations(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(0, cancellationToken);
            if (_CustomerLocations.CustomerLocationGrpc.Any())
            {
                if (takeAmount <= 0)
                {
                    return _CustomerLocations;
                }

                ListCustomerLocationGrpc returnList = new ListCustomerLocationGrpc();
                IQueryable<CustomerLocationGrpc> query = _CustomerLocations.CustomerLocationGrpc.AsQueryable().Skip(position).Take(takeAmount);
                returnList.CustomerLocationGrpc.AddRange(query);
                return returnList;
            }
            else
            {
                await PopulateCustomerLocationsAsync(cancellationToken);
                return _CustomerLocations;
            }
        }

        public async Task<ListCustomerProjectAssociationGrpc> GetAllCustomerProjectAssociations(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_CustomerProjectAssociations.CustomerProjectAssociationGrpc.Any())
            {
                if (takeAmount <= 0)
                {
                    return _CustomerProjectAssociations;
                }

                ListCustomerProjectAssociationGrpc returnList = new ListCustomerProjectAssociationGrpc();
                IQueryable<CustomerProjectAssociationGrpc> query = _CustomerProjectAssociations.CustomerProjectAssociationGrpc.AsQueryable().Skip(position).Take(takeAmount);
                returnList.CustomerProjectAssociationGrpc.AddRange(query);
                return returnList;
            }
            else
            {
                await PopulateCustomerProjectAssociationsAsync(cancellationToken);
                return _CustomerProjectAssociations;
            }
        }

        public async Task<ListCustomerProjectAssociationGrpc> GetAllCustomerProjectAssociationsByUserId(string userId ,CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            _FilteredLocations.CustomerLocationGrpc.Clear();
            if (_CustomerProjectAssociations.CustomerProjectAssociationGrpc.Any() && _CustomerBusinessUserAssociations.CustomerBusinessUserAssociationGrpc.Any())
            {
                string upperUserId = userId.ToUpperInvariant();
                ParsingConfig parsingConfig = new ParsingConfig();
                CustomerBusinessUserAssociationGrpc? user = new CustomerBusinessUserAssociationGrpc();
                await HandleFilterCase<CustomerBusinessUserAssociationGrpc>($"UserGuid != null && UserGuid.ToUpperInvariant() == \"{upperUserId}\"", parsingConfig, 
                    filterList =>
                    {
                        ListCustomerBusinessUserAssociationGrpc returnList = new ListCustomerBusinessUserAssociationGrpc();
                        returnList.CustomerBusinessUserAssociationGrpc.AddRange(filterList);
                        user = returnList.CustomerBusinessUserAssociationGrpc.FirstOrDefault();
                    }, cancellationToken);
                
                if (user != null)
                {
                    if (user.CustomerBusinessHierarchyList != null)
                    {
                        List<CustomerLocationGrpc>? customers = JsonConvert.DeserializeObject<List<CustomerLocationGrpc>>(user.CustomerBusinessHierarchyList);
                        if (customers != null)
                        {
                            foreach (CustomerLocationGrpc customer in customers)
                            {
                                if (customer.IsActive == true)
                                {
                                    if (customer.CustomerBusinessHierarchyGuid != null)
                                    {
                                        List<CustomerLocationGrpc> filteredLocations = _CustomerLocations.CustomerLocationGrpc.Where(x => x.CustomerBusinessHierarchyGuid.ToUpperInvariant() == customer.CustomerBusinessHierarchyGuid.ToUpperInvariant()).ToList();
                                        _FilteredLocations.CustomerLocationGrpc.AddRange(filteredLocations);
                                        foreach (CustomerLocationGrpc customerLocation in _FilteredLocations.CustomerLocationGrpc)
                                        {
                                            List<CustomerProjectAssociationGrpc> customerProjects = _CustomerProjectAssociations.CustomerProjectAssociationGrpc.Where(x => x.CustomerLocationGuid.ToUpperInvariant() == customerLocation.Id.ToUpperInvariant()).ToList();
                                            _FilteredCustomerProjectAssociations.CustomerProjectAssociationGrpc.AddRange(customerProjects);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                return _FilteredCustomerProjectAssociations;
            }
            else
            {
                await PopulateCustomerProjectAssociationsAsync(cancellationToken);
                return _FilteredCustomerProjectAssociations;
            }
        }

        public async Task<ListCustomerSalesEntityGrpc> GetAllCustomerSalesEntities(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_CustomerSalesEntities.CustomerSalesEntityGrpc.Any())
            {
                if (takeAmount <= 0)
                {
                    return _CustomerSalesEntities;
                }

                ListCustomerSalesEntityGrpc returnList = new ListCustomerSalesEntityGrpc();
                IQueryable<CustomerSalesEntityGrpc> query = _CustomerSalesEntities.CustomerSalesEntityGrpc.AsQueryable().Skip(position).Take(takeAmount);
                returnList.CustomerSalesEntityGrpc.AddRange(query);
                return returnList;
            }
            else
            {
                await PopulateCustomerSalesEntitiesAsync(cancellationToken);
                return _CustomerSalesEntities;
            }
        }

        public async Task<ListCustomerBusinessUserAssociationGrpc> GetCustomerBusinessUserAssociations(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_CustomerBusinessUserAssociations.CustomerBusinessUserAssociationGrpc.Any())
            {
                if (takeAmount <= 0)
                {
                    return _CustomerBusinessUserAssociations;
                }

                ListCustomerBusinessUserAssociationGrpc returnList = new ListCustomerBusinessUserAssociationGrpc();
                IQueryable<CustomerBusinessUserAssociationGrpc> query = _CustomerBusinessUserAssociations.CustomerBusinessUserAssociationGrpc.AsQueryable().Skip(position).Take(takeAmount);
                returnList.CustomerBusinessUserAssociationGrpc.AddRange(query);
                return returnList;
            }
            else
            {
                await PopulateCustomerBusinessUserAssociationsAsync(cancellationToken);
                return _CustomerBusinessUserAssociations;
            }
        }

        #endregion

        #region Project

        public async Task<ListPlatformGrpc> GetAllPlatforms(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_Platforms.PlatformGrpc.Any())
            {
                if (takeAmount <= 0)
                {
                    return _Platforms;
                }

                ListPlatformGrpc returnList = new ListPlatformGrpc();
                IQueryable<PlatformGrpc> query = _Platforms.PlatformGrpc.AsQueryable().Skip(position).Take(takeAmount);
                returnList.PlatformGrpc.AddRange(query);
                return returnList;
            }
            else
            {
                await PopulatePlatformsAsync(cancellationToken);
                return _Platforms;
            }
        }

        public async Task<ListProgramGrpc> GetAllPrograms(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_Programs.ProgramGrpc.Any())
            {
                if (takeAmount <= 0)
                {
                    return _Programs;
                }

                ListProgramGrpc returnList = new ListProgramGrpc();
                IQueryable<ProgramGrpc> query = _Programs.ProgramGrpc.AsQueryable().Skip(position).Take(takeAmount);
                returnList.ProgramGrpc.AddRange(query);
                return returnList;
            }
            else
            {
                await PopulateProgramsAsync(cancellationToken);
                return _Programs;
            }
        }

        public async Task<ListProjectGrpc> GetAllProjects(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_Projects.ProjectGrpc.Any())
            {
                if (takeAmount <= 0)
                {
                    return _Projects;
                }

                ListProjectGrpc returnList = new ListProjectGrpc();
                IQueryable<ProjectGrpc> query = _Projects.ProjectGrpc.AsQueryable().Skip(position).Take(takeAmount);
                returnList.ProjectGrpc.AddRange(query);
                return returnList;
            }
            else
            {
                await PopulateProjectsAsync(cancellationToken);
                return _Projects;
            }
        }

        public async Task<ListMilestoneGrpc> GetAllMilestones(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_Milestones.MilestoneGrpc.Any())
            {
                if (takeAmount <= 0)
                {
                    return _Milestones;
                }

                ListMilestoneGrpc returnList = new ListMilestoneGrpc();
                IQueryable<MilestoneGrpc> query = _Milestones.MilestoneGrpc.AsQueryable().Skip(position).Take(takeAmount);
                returnList.MilestoneGrpc.AddRange(query);
                return returnList;
            }
            else
            {
                await PopulateMilestonesAsync(cancellationToken);
                return _Milestones;
            }
        }

        #endregion

        #region Vehicle

        public async Task<ListVehicleGrpc> GetAllVehicles(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_Vehicles.VehicleGrpc.Any())
            {
                if (takeAmount <= 0)
                {
                    return _Vehicles;
                }

                ListVehicleGrpc returnList = new ListVehicleGrpc();
                IQueryable<VehicleGrpc> query = _Vehicles.VehicleGrpc.AsQueryable().Skip(position).Take(takeAmount);
                returnList.VehicleGrpc.AddRange(query);
                return returnList;
            }
            else
            {
                await PopulateVehiclesAsync(cancellationToken);
                return _Vehicles;
            }
        }

        #endregion

        #region SupplierGroup

        public async Task<ListSupplierGroupGrpc> GetAllSupplierGroups(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_SupplierGroups.SupplierGroupGrpc.Any())
            {
                if (takeAmount <= 0)
                {
                    return _SupplierGroups;
                }

                ListSupplierGroupGrpc returnList = new ListSupplierGroupGrpc();
                IQueryable<SupplierGroupGrpc> query = _SupplierGroups.SupplierGroupGrpc.AsQueryable().Skip(position).Take(takeAmount);
                returnList.SupplierGroupGrpc.AddRange(query);
                return returnList;
            }
            else
            {
                await PopulateSupplierGroupsAsync(cancellationToken);
                return _SupplierGroups;
            }
        }

        #endregion

        #region Supplier

        public async Task<ListSupplierGrpc> GetAllSuppliers(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_Suppliers.SupplierGrpc.Any())
            {
                if (takeAmount <= 0)
                {
                    return _Suppliers;
                }

                ListSupplierGrpc returnList = new ListSupplierGrpc();
                IQueryable<SupplierGrpc> query = _Suppliers.SupplierGrpc.AsQueryable().Skip(position).Take(takeAmount);
                returnList.SupplierGrpc.AddRange(query);
                return returnList;
            }
            else
            {
                await PopulateSuppliersAsync(cancellationToken);
                return _Suppliers;
            }
        }

        #endregion

        #region ProjectEngineerAssociation

        public async Task<ListProjectEngineeringAssociationGrpc> GetAllProjectEngineeringAssociations(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ProjectEngineeringAssociations.ProjectEngineeringAssociationGrpc.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ProjectEngineeringAssociations;
                }

                ListProjectEngineeringAssociationGrpc returnList = new ListProjectEngineeringAssociationGrpc();
                IQueryable<ProjectEngineeringAssociationGrpc> query = _ProjectEngineeringAssociations.ProjectEngineeringAssociationGrpc.AsQueryable().Skip(position).Take(takeAmount);
                returnList.ProjectEngineeringAssociationGrpc.AddRange(query);
                return returnList;
            }
            else
            {
                await PopulateProjectEngineeringAssociationsAsync(cancellationToken);
                return _ProjectEngineeringAssociations;
            }
        }
        #endregion

        async Task<Result<bool>> PopulateMasterData(CancellationToken cancellationToken)
        {
            await PopulateCurrenciesAsync(cancellationToken);
            return true;
        }

        #endregion

        #region Data Imports

        #region Currency
        public async Task<bool> PopulateCurrenciesAsync(CancellationToken cancellationToken)
        {
            if (!_CurrencyRefreshInProgress)   
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CurrencyHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetCurrenciesQuery, List<CurrencyGrpc>>>();
                    _CurrencyRefreshInProgress = true;
                    GetCurrenciesQuery query = new GetCurrenciesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<CurrencyGrpc>> results = await _CurrencyHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _Currencies.CurrencyGrpc.Clear();
                        _Currencies.CurrencyGrpc.AddRange(results.Value);
                    }

                    _CurrencyRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region Customer

        public async Task<bool> PopulateCustomersAsync(CancellationToken cancellationToken)
        {
            if (!_CustomerRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CustomerHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetAllCustomerBusinessUnitsQuery, List<CustomerGrpc>>>();
                    _CustomerRefreshInProgress = true;
                    GetAllCustomerBusinessUnitsQuery query = new GetAllCustomerBusinessUnitsQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<CustomerGrpc>> results = await _CustomerHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _Customers.CustomerGrpc.Clear();
                        _Customers.CustomerGrpc.AddRange(results.Value);
                    }

                    _CustomerRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<bool> PopulateCustomerLocationsAsync(CancellationToken cancellationToken)
        {
            if (!_CustomerLocationRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CustomerLocationHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetAllCustomerLocationsQuery, List<CustomerLocationGrpc>>>();
                    _CustomerLocationRefreshInProgress = true;
                    GetAllCustomerLocationsQuery query = new GetAllCustomerLocationsQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<CustomerLocationGrpc>> results = await _CustomerLocationHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _CustomerLocations.CustomerLocationGrpc.Clear();
                        _CustomerLocations.CustomerLocationGrpc.AddRange(results.Value);
                    }

                    _CustomerLocationRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<bool> PopulateCustomerProjectAssociationsAsync(CancellationToken cancellationToken)
        {
            if (!_CustomerProjectAssociationsRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CustomerProjectAssociationsHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetAllCustomerProjectAssociationsQuery, List<CustomerProjectAssociationGrpc>>>();
                    _CustomerProjectAssociationsRefreshInProgress = true;
                    GetAllCustomerProjectAssociationsQuery query = new GetAllCustomerProjectAssociationsQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<CustomerProjectAssociationGrpc>> results = await _CustomerProjectAssociationsHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _CustomerProjectAssociations.CustomerProjectAssociationGrpc.Clear();
                        _CustomerProjectAssociations.CustomerProjectAssociationGrpc.AddRange(results.Value);
                    }

                    _CustomerProjectAssociationsRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<bool> PopulateCustomerSalesEntitiesAsync(CancellationToken cancellationToken)
        {
            if (!_CustomerSalesEntitiesRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CustomerSalesEntitiesHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetAllCustomerSalesEntitiesQuery, List <CustomerSalesEntityGrpc>>>();
                    _CustomerSalesEntitiesRefreshInProgress = true;
                    GetAllCustomerSalesEntitiesQuery query = new GetAllCustomerSalesEntitiesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<CustomerSalesEntityGrpc>> results = await _CustomerSalesEntitiesHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _CustomerSalesEntities.CustomerSalesEntityGrpc.Clear();
                        _CustomerSalesEntities.CustomerSalesEntityGrpc.AddRange(results.Value);
                    }

                    _CustomerSalesEntitiesRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<bool> PopulateCustomerBusinessUserAssociationsAsync(CancellationToken cancellationToken)
        {
            if (!_CustomerBusinessUserAssociationsRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CustomerBusinessUserAssociationsHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetCustomerBusinessUserAssociationsQuery, List<CustomerBusinessUserAssociationGrpc>>>();
                    _CustomerBusinessUserAssociationsRefreshInProgress = true;
                    GetCustomerBusinessUserAssociationsQuery query = new GetCustomerBusinessUserAssociationsQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<CustomerBusinessUserAssociationGrpc>> results = await _CustomerBusinessUserAssociationsHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _CustomerBusinessUserAssociations.CustomerBusinessUserAssociationGrpc.Clear();
                        _CustomerBusinessUserAssociations.CustomerBusinessUserAssociationGrpc.AddRange(results.Value);
                    }

                    _CustomerBusinessUserAssociationsRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region Project

        public async Task<bool> PopulatePlatformsAsync(CancellationToken cancellationToken)
        {
            if (!_PlatformRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _PlatformHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetAllPlatformHierarchiesQuery, List<PlatformGrpc>>>();
                    _PlatformRefreshInProgress = true;
                    GetAllPlatformHierarchiesQuery query = new GetAllPlatformHierarchiesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<PlatformGrpc>> results = await _PlatformHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _Platforms.PlatformGrpc.Clear();
                        _Platforms.PlatformGrpc.AddRange(results.Value);
                    }

                    _PlatformRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<bool> PopulateProgramsAsync(CancellationToken cancellationToken)
        {
            if (!_ProgramRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _ProgramHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetAllProgramHierarchiesQuery, List<ProgramGrpc>>>();
                    _ProgramRefreshInProgress = true;
                    GetAllProgramHierarchiesQuery query = new GetAllProgramHierarchiesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<ProgramGrpc>> results = await _ProgramHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _Programs.ProgramGrpc.Clear();
                        _Programs.ProgramGrpc.AddRange(results.Value);
                    }

                    _ProgramRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<bool> PopulateProjectsAsync(CancellationToken cancellationToken)
        {
            if (!_ProjectRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _ProjectHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetAllProjectHierarchiesQuery, List<ProjectGrpc>>>();
                    _ProjectRefreshInProgress = true;
                    GetAllProjectHierarchiesQuery query = new GetAllProjectHierarchiesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<ProjectGrpc>> results = await _ProjectHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _Projects.ProjectGrpc.Clear();
                        _Projects.ProjectGrpc.AddRange(results.Value);
                    }

                    _ProjectRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<bool> PopulateMilestonesAsync(CancellationToken cancellationToken)
        {
            if (!_MilestoneRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _MilestoneHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetAllMilestoneHierarchiesQuery, List<MilestoneGrpc>>>();
                    _MilestoneRefreshInProgress = true;
                    GetAllMilestoneHierarchiesQuery query = new GetAllMilestoneHierarchiesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<MilestoneGrpc>> results = await _MilestoneHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _Milestones.MilestoneGrpc.Clear();
                        _Milestones.MilestoneGrpc.AddRange(results.Value);
                    }

                    _MilestoneRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region Vehicle

        public async Task<bool> PopulateVehiclesAsync(CancellationToken cancellationToken)
        {
            if (!_VehicleRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _VehicleHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetAllVehiclesQuery, List<VehicleGrpc>>>();
                    _VehicleRefreshInProgress = true;
                    GetAllVehiclesQuery query = new GetAllVehiclesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<VehicleGrpc>> results = await _VehicleHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _Vehicles.VehicleGrpc.Clear();
                        _Vehicles.VehicleGrpc.AddRange(results.Value);
                    }

                    _VehicleRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region SupplierGroup

        public async Task<bool> PopulateSupplierGroupsAsync(CancellationToken cancellationToken)
        {
            if (!_SupplierGroupRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _SupplierGroupHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetAllSupplierGroupsQuery, List<SupplierGroupGrpc>>>();
                    _SupplierGroupRefreshInProgress = true;
                    GetAllSupplierGroupsQuery query = new GetAllSupplierGroupsQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<SupplierGroupGrpc>> results = await _SupplierGroupHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _SupplierGroups.SupplierGroupGrpc.Clear();
                        _SupplierGroups.SupplierGroupGrpc.AddRange(results.Value);
                    }

                    _SupplierGroupRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region Supplier

        public async Task<bool> PopulateSuppliersAsync(CancellationToken cancellationToken)
        {
            if (!_SupplierRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _SupplierHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetAllSuppliersQuery, List<SupplierGrpc>>>();
                    _SupplierRefreshInProgress = true;
                    GetAllSuppliersQuery query = new GetAllSuppliersQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<SupplierGrpc>> results = await _SupplierHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _Suppliers.SupplierGrpc.Clear();
                        _Suppliers.SupplierGrpc.AddRange(results.Value);
                    }

                    _SupplierRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region ProjectEngineerAssociation

        public async Task<bool> PopulateProjectEngineeringAssociationsAsync(CancellationToken cancellationToken)
        {
            if (!_ProjectEngineeringAssociationRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _ProjectEngineeringAssociationHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetAllProjectEngineeringAssociationQuery, List<ProjectEngineeringAssociationGrpc>>>();
                    _ProjectEngineeringAssociationRefreshInProgress = true;
                    GetAllProjectEngineeringAssociationQuery query = new GetAllProjectEngineeringAssociationQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<ProjectEngineeringAssociationGrpc>> results = await _ProjectEngineeringAssociationHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ProjectEngineeringAssociations.ProjectEngineeringAssociationGrpc.Clear();
                        _ProjectEngineeringAssociations.ProjectEngineeringAssociationGrpc.AddRange(results.Value);
                    }

                    _ProjectEngineeringAssociationRefreshInProgress = false;
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
                    "CURRENCYGRPC" => _Currencies.CurrencyGrpc.Cast<T>().Where(func).ToList(),
                    "CUSTOMERGRPC" => _Customers.CustomerGrpc.Cast<T>().Where(func).ToList(),
                    "CUSTOMERLOCATIONGRPC" => _CustomerLocations.CustomerLocationGrpc.Cast<T>().Where(func).ToList(),
                    "CUSTOMERSALESENTITYGRPC" => _CustomerSalesEntities.CustomerSalesEntityGrpc.Cast<T>().Where(func).ToList(),
                    "CUSTOMERPROJECTASSOCIATIONGRPC" => _CustomerProjectAssociations.CustomerProjectAssociationGrpc.Cast<T>().Where(func).ToList(),
                    "CUSTOMERBUSINESSUSERASSOCIATIONGRPC" => _CustomerBusinessUserAssociations.CustomerBusinessUserAssociationGrpc.Cast<T>().Where(func).ToList(),
                    "MILESTONEGRPC" => _Milestones.MilestoneGrpc.Cast<T>().Where(func).ToList(),
                    "PLATFORMGRPC" => _Platforms.PlatformGrpc.Cast<T>().Where(func).ToList(),
                    "PROGRAMGRPC" => _Programs.ProgramGrpc.Cast<T>().Where(func).ToList(),
                    "PROJECTGRPC" => _Projects.ProjectGrpc.Cast<T>().Where(func).ToList(),
                    "VEHICLEGRPC" => _Vehicles.VehicleGrpc.Cast<T>().Where(func).ToList(),
                    "SUPPLIERGROUPGRPC" => _SupplierGroups.SupplierGroupGrpc.Cast<T>().Where(func).ToList(),
                    "SUPPLIERGRPC" => _Suppliers.SupplierGrpc.Cast<T>().Where(func).ToList(),
                    "PROJECTENGINEERINGASSOCIATIONGRPC" => _ProjectEngineeringAssociations.ProjectEngineeringAssociationGrpc.Cast<T>().Where(func).ToList(),
                    _ => throw new NotSupportedException($"Filtering not supported for type {typeof(T).Name}")
                };
            }, cancellationToken);
        }

        void PopulateSampleData()
        {
            _Currencies = SampleMasterDataService.PopulateCurrencyGrpc();
            _Customers = SampleMasterDataService.PopulateCustomerGrpc();
            _CustomerLocations = SampleMasterDataService.PopulateCustomerLocationsData();
            _CustomerSalesEntities = SampleMasterDataService.PopulateCustomerSalesEntityGrpc();
            _CustomerProjectAssociations = SampleMasterDataService.PopulateCustomerProjectAssociationGrpc();
            _CustomerBusinessUserAssociations = SampleMasterDataService.PopulateCustomerBusinessUserAssociationGrpc();
            _Platforms = SampleMasterDataService.PopulatePlatformGrpc();
            _Programs = SampleMasterDataService.PopulateProgramGrpc();
            _Projects = SampleMasterDataService.PopulateProjectGrpc();
            _Milestones = SampleMasterDataService.PopulateMilestoneGrpc();
            _Vehicles = SampleMasterDataService.PopulateVehicleGrpc();
            _SupplierGroups = SampleMasterDataService.PopulateSupplierGroupGrpc();
            _Suppliers = SampleMasterDataService.PopulateSupplierGrpc();
        }
    }
}
