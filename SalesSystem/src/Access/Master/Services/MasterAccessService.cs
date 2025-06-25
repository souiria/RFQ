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

        ListCurrencyData _Currencies;
        ListCurrencyData _FilteredCurrencies;

        #endregion

        #region Customer

        ListCustomerData _Customers;
        ListCustomerData _FilteredCustomers;
        ListCustomerLocationData _CustomerLocations;
        ListCustomerLocationData _FilteredLocations;
        ListCustomerSalesEntityData _CustomerSalesEntities;
        ListCustomerSalesEntityData _FilteredCustomerSalesEntities;
        ListCustomerProjectAssociationData _CustomerProjectAssociations;
        ListCustomerProjectAssociationData _FilteredCustomerProjectAssociations;
        ListCustomerBusinessUserAssociationData _CustomerBusinessUserAssociations;
        ListCustomerBusinessUserAssociationData _FilteredCustomerBusinessUserAssociations;

        #endregion

        #region Project

        ListPlatformData _Platforms;
        ListPlatformData _FilteredPlatforms;
        ListProgramData _Programs;
        ListProgramData _FilteredPrograms;
        ListProjectData _Projects;
        ListProjectData _FilteredProjects;
        ListMilestoneData _Milestones;
        ListMilestoneData _FilteredMilestones;

        #endregion

        #region Vehicle

        ListVehicleData _Vehicles;
        ListVehicleData _FilteredVehicles;

        #endregion

        #endregion

        #region Fields and Properties

        #region Currency

        IQueryHandler<GetCurrenciesQuery, List<CurrencyData>>? _CurrencyHandler;
        bool _CurrencyRefreshInProgress;

        #endregion

        #region Customer

        IQueryHandler<GetAllCustomerBusinessUnitsQuery, List<CustomerData>>? _CustomerHandler;
        IQueryHandler<GetAllCustomerLocationsQuery, List<CustomerLocationData>>? _CustomerLocationHandler;
        IQueryHandler<GetAllCustomerProjectAssociationsQuery, List<CustomerProjectAssociationData>>? _CustomerProjectAssociationsHandler;
        IQueryHandler<GetAllCustomerSalesEntitiesQuery, List<CustomerSalesEntityData>>? _CustomerSalesEntitiesHandler;
        IQueryHandler<GetCustomerBusinessUserAssociationsQuery, List<CustomerBusinessUserAssociationData>>? _CustomerBusinessUserAssociationsHandler;
        bool _CustomerRefreshInProgress;
        bool _CustomerLocationRefreshInProgress;
        bool _CustomerProjectAssociationsRefreshInProgress;
        bool _CustomerSalesEntitiesRefreshInProgress;
        bool _CustomerBusinessUserAssociationsRefreshInProgress;

        #endregion

        #region Project

        IQueryHandler<GetAllPlatformHierarchiesQuery, List<PlatformData>>? _PlatformHandler;
        IQueryHandler<GetAllProgramHierarchiesQuery, List<ProgramData>>? _ProgramHandler;
        IQueryHandler<GetAllProjectHierarchiesQuery, List<ProjectData>>? _ProjectHandler;
        IQueryHandler<GetAllMilestoneHierarchiesQuery, List<MilestoneData>>? _MilestoneHandler;
        bool _PlatformRefreshInProgress;
        bool _ProgramRefreshInProgress;
        bool _ProjectRefreshInProgress;
        bool _MilestoneRefreshInProgress;

        #endregion

        #region Vehicle

        IQueryHandler<GetAllVehiclesQuery, List<VehicleData>>? _VehicleHandler;
        bool _VehicleRefreshInProgress;

        #endregion

        readonly IServiceProvider _ServiceProvider;

        #endregion

        #region Constructor
        public MasterAccessService(IServiceProvider serviceProvider, bool testing = false)
        {

            #region Currency

            _Currencies = new ListCurrencyData();
            _FilteredCurrencies = new ListCurrencyData();
            _CurrencyRefreshInProgress = false;

            #endregion

            #region Customer

            _Customers = new ListCustomerData();
            _FilteredCustomers = new ListCustomerData();
            _CustomerLocations = new ListCustomerLocationData();
            _FilteredLocations = new ListCustomerLocationData();
            _CustomerSalesEntities = new ListCustomerSalesEntityData();
            _FilteredCustomerSalesEntities = new ListCustomerSalesEntityData();
            _CustomerProjectAssociations = new ListCustomerProjectAssociationData();
            _FilteredCustomerProjectAssociations = new ListCustomerProjectAssociationData();
            _CustomerBusinessUserAssociations = new ListCustomerBusinessUserAssociationData();
            _FilteredCustomerBusinessUserAssociations = new ListCustomerBusinessUserAssociationData();
            _CustomerRefreshInProgress = false;
            _CustomerLocationRefreshInProgress = false;
            _CustomerProjectAssociationsRefreshInProgress = false;
            _CustomerSalesEntitiesRefreshInProgress = false;
            _CustomerBusinessUserAssociationsRefreshInProgress = false;

            #endregion

            #region Project

            _Platforms = new ListPlatformData();
            _FilteredPlatforms = new ListPlatformData();
            _Programs = new ListProgramData();
            _FilteredPrograms = new ListProgramData();
            _Projects = new ListProjectData();
            _FilteredProjects = new ListProjectData();
            _Milestones = new ListMilestoneData();
            _FilteredMilestones = new ListMilestoneData();

            _PlatformRefreshInProgress = false;
            _ProgramRefreshInProgress = false;
            _ProjectRefreshInProgress = false;
            _MilestoneRefreshInProgress = false;

            #endregion

            #region Vehicle

            _Vehicles = new ListVehicleData();
            _FilteredVehicles = new ListVehicleData();
            _VehicleRefreshInProgress = false;

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

        public async Task<ListCurrencyData> GetAllCurrencies(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_Currencies.CurrencyData.Any())
            {
                return _Currencies;
            }
            else
            {
                await PopulateCurrenciesAsync(cancellationToken);
                return _Currencies;
            }
        }

        public async Task<ListCurrencyData> GetCurrenciesById(string id ,CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_Currencies.CurrencyData.Any())
            {
                _FilteredCurrencies.CurrencyData.Clear();
                List<CurrencyData> filteredList = _Currencies.CurrencyData.Where(x => x.Id == id).ToList();
                _FilteredCurrencies.CurrencyData.AddRange(filteredList);
                return _FilteredCurrencies;
            }
            else
            {
                await PopulateCurrenciesAsync(cancellationToken);
                return _FilteredCurrencies;
            }
        }

        #endregion

        #region Customer

        public async Task<ListCustomerData> GetAllCustomerBusinessUnits(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_Customers.CustomerData.Any())
            {
                return _Customers;
            }
            else
            {
                await PopulateCustomersAsync(cancellationToken);
                return _Customers;
            }
        }

        public async Task<ListCustomerData> GetCustomerBusinessUnitsById(string id, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            _FilteredCustomers.CustomerData.Clear();
            if (_Customers.CustomerData.Any())
            {
                List<CustomerData> filteredCustomers = _Customers.CustomerData.Where(x => x.Id == id).ToList();
                _FilteredCustomers.CustomerData.AddRange(filteredCustomers);
                return _FilteredCustomers;
            }
            else
            {
                await PopulateCustomersAsync(cancellationToken);
                return _FilteredCustomers;
            }
        }

        public async Task<ListCustomerLocationData> GetAllCustomerLocations(CancellationToken cancellationToken)
        {
            await Task.Delay(0, cancellationToken);
            if (_CustomerLocations.CustomerLocationData.Any())
            {
                return _CustomerLocations;
            }
            else
            {
                await PopulateCustomerLocationsAsync(cancellationToken);
                return _CustomerLocations;
            }
        }

        public async Task<ListCustomerLocationData> GetCustomerLocationsById(string id ,CancellationToken cancellationToken)
        {
            await Task.Delay(0, cancellationToken);
            _FilteredLocations.CustomerLocationData.Clear();
            if (_CustomerLocations.CustomerLocationData.Any())
            {
                List<CustomerLocationData> filteredLocations = _CustomerLocations.CustomerLocationData.Where(x => x.Id == id).ToList();
                _FilteredLocations.CustomerLocationData.AddRange(filteredLocations);
                return _FilteredLocations;
            }
            else
            {
                await PopulateCustomerLocationsAsync(cancellationToken);
                return _FilteredLocations;
            }
        }

        public async Task<ListCustomerLocationData> GetCustomerLocationsByUserId(string userId ,CancellationToken cancellationToken)
        {
            await Task.Delay(0, cancellationToken);
            _FilteredLocations.CustomerLocationData.Clear();
            if (_CustomerLocations.CustomerLocationData.Any() && _CustomerBusinessUserAssociations.CustomerBusinessUserAssociationData.Any())
            {
                CustomerBusinessUserAssociationData? user = _CustomerBusinessUserAssociations.CustomerBusinessUserAssociationData.Where(x => x.UserGuid == userId).FirstOrDefault();
                if (user != null)
                {
                    if (user.CustomerBusinessHierarchyList != null)
                    {
                        List<CustomerLocationData>? userLocations = JsonConvert.DeserializeObject<List<CustomerLocationData>>(user.CustomerBusinessHierarchyList);
                        if (userLocations != null)
                        {
                            foreach (CustomerLocationData location in userLocations)
                            {
                                if (location.IsActive == true)
                                {
                                    List<CustomerLocationData> filteredLocations = _CustomerLocations.CustomerLocationData.Where(x => x.CustomerBusinessHierarchyGuid == location.CustomerBusinessHierarchyGuid).ToList();
                                    _FilteredLocations.CustomerLocationData.AddRange(filteredLocations);
                                }
                            }
                        }
                    }
                }

                return _FilteredLocations;
            }
            else
            {
                await PopulateCustomerLocationsAsync(cancellationToken);
                await PopulateCustomerBusinessUserAssociationsAsync(cancellationToken);
                return _FilteredLocations;
            }
        }

        public async Task<ListCustomerProjectAssociationData> GetAllCustomerProjectAssociations(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_CustomerProjectAssociations.CustomerProjectAssociationData.Any())
            {
                return _CustomerProjectAssociations;
            }
            else
            {
                await PopulateCustomerProjectAssociationsAsync(cancellationToken);
                return _CustomerProjectAssociations;
            }
        }

        public async Task<ListCustomerProjectAssociationData> GetAllCustomerProjectAssociationsByUserId(string userId ,CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            _FilteredLocations.CustomerLocationData.Clear();
            if (_CustomerProjectAssociations.CustomerProjectAssociationData.Any() && _CustomerBusinessUserAssociations.CustomerBusinessUserAssociationData.Any())
            {
                CustomerBusinessUserAssociationData? user = GetCustomerBusinessUserAssociationsByUserId(userId, cancellationToken).Result.CustomerBusinessUserAssociationData.FirstOrDefault();
                if (user != null)
                {
                    if (user.CustomerBusinessHierarchyList != null)
                    {
                        List<CustomerLocationData>? customers = JsonConvert.DeserializeObject<List<CustomerLocationData>>(user.CustomerBusinessHierarchyList);
                        if (customers != null)
                        {
                            foreach (CustomerLocationData customer in customers)
                            {
                                if (customer.IsActive == true)
                                {
                                    if (customer.CustomerBusinessHierarchyGuid != null)
                                    {
                                        List<CustomerLocationData> filteredLocations = _CustomerLocations.CustomerLocationData.Where(x => x.CustomerBusinessHierarchyGuid == customer.CustomerBusinessHierarchyGuid).ToList();
                                        _FilteredLocations.CustomerLocationData.AddRange(filteredLocations);
                                        foreach (CustomerLocationData customerLocation in _FilteredLocations.CustomerLocationData)
                                        {
                                            List<CustomerProjectAssociationData> customerProjects = _CustomerProjectAssociations.CustomerProjectAssociationData.Where(x => x.CustomerLocationGuid == customerLocation.Id).ToList();
                                            _FilteredCustomerProjectAssociations.CustomerProjectAssociationData.AddRange(customerProjects);
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

        public async Task<ListCustomerSalesEntityData> GetAllCustomerSalesEntities(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_CustomerSalesEntities.CustomerSalesEntityData.Any())
            {
                return _CustomerSalesEntities;
            }
            else
            {
                await PopulateCustomerSalesEntitiesAsync(cancellationToken);
                return _CustomerSalesEntities;
            }
        }

        public async Task<ListCustomerSalesEntityData> GetAllCustomerSalesByUserIdEntities(string userId ,CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            _FilteredCustomerSalesEntities.CustomerSalesEntityData.Clear();
            if (_CustomerSalesEntities.CustomerSalesEntityData.Any())
            {
                ListCustomerLocationData locations = await GetCustomerLocationsByUserId(userId, cancellationToken);
                foreach(CustomerLocationData location in locations.CustomerLocationData)
                {
                    List<CustomerSalesEntityData> salesByLocation = _CustomerSalesEntities.CustomerSalesEntityData.Where(x => x.CustomerHierarchyGuid == location.Id).ToList();
                    _FilteredCustomerSalesEntities.CustomerSalesEntityData.AddRange(salesByLocation);
                }

                return _FilteredCustomerSalesEntities;
            }
            else
            {
                await PopulateCustomerSalesEntitiesAsync(cancellationToken);
                return _FilteredCustomerSalesEntities;
            }
        }

        public async Task<ListCustomerBusinessUserAssociationData> GetCustomerBusinessUserAssociations(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_CustomerBusinessUserAssociations.CustomerBusinessUserAssociationData.Any())
            {
                return _CustomerBusinessUserAssociations;
            }
            else
            {
                await PopulateCustomerBusinessUserAssociationsAsync(cancellationToken);
                return _CustomerBusinessUserAssociations;
            }
        }
        public async Task<ListCustomerBusinessUserAssociationData> GetCustomerBusinessUserAssociationsByUserId(string userId, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            _FilteredCustomerBusinessUserAssociations.CustomerBusinessUserAssociationData.Clear();
            if (_CustomerBusinessUserAssociations.CustomerBusinessUserAssociationData.Any())
            {
                List<CustomerBusinessUserAssociationData> filteredCustomerBusinessUserAssociationData = _CustomerBusinessUserAssociations.CustomerBusinessUserAssociationData.Where(x => x.UserGuid == userId).ToList();
                _FilteredCustomerBusinessUserAssociations.CustomerBusinessUserAssociationData.AddRange(filteredCustomerBusinessUserAssociationData);
                return _FilteredCustomerBusinessUserAssociations;
            }
            else
            {
                await PopulateCustomerBusinessUserAssociationsAsync(cancellationToken);
                return _FilteredCustomerBusinessUserAssociations;
            }
        }

        #endregion

        #region Project

        public async Task<ListPlatformData> GetAllPlatforms(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_Platforms.PlatformData.Any())
            {
                return _Platforms;
            }
            else
            {
                await PopulatePlatformsAsync(cancellationToken);
                return _Platforms;
            }
        }
        public async Task<ListPlatformData> GetPlatformsById(string id ,CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_Platforms.PlatformData.Any())
            {
                _FilteredPlatforms.PlatformData.Clear();
                List<PlatformData> filteredPlatforms = _Platforms.PlatformData.Where(x => x.Id == id).ToList();
                _FilteredPlatforms.PlatformData.AddRange(filteredPlatforms);
                return _FilteredPlatforms;
            }
            else
            {
                await PopulatePlatformsAsync(cancellationToken);
                return _FilteredPlatforms;
            }
        }

        public async Task<ListProgramData> GetAllPrograms(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_Programs.ProgramData.Any())
            {
                return _Programs;
            }
            else
            {
                await PopulateProgramsAsync(cancellationToken);
                return _Programs;
            }
        }
        public async Task<ListProgramData> GetProgramsById(string id,CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_Programs.ProgramData.Any())
            {
                _FilteredPrograms.ProgramData.Clear();
                List<ProgramData> filteredPrograms = _Programs.ProgramData.Where(x => x.Id == id).ToList();
                _FilteredPrograms.ProgramData.AddRange(filteredPrograms);
                return _FilteredPrograms;
            }
            else
            {
                await PopulateProgramsAsync(cancellationToken);
                return _FilteredPrograms;
            }
        }

        public async Task<ListProjectData> GetAllProjects(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_Projects.ProjectData.Any())
            {
                return _Projects;
            }
            else
            {
                await PopulateProjectsAsync(cancellationToken);
                return _Projects;
            }
        }

        public async Task<ListProjectData> GetProjectsById(string id, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_Projects.ProjectData.Any())
            {
                _FilteredProjects.ProjectData.Clear();
                List<ProjectData> filteredProjects = _Projects.ProjectData.Where(x => x.Id == id).ToList();
                _FilteredProjects.ProjectData.AddRange(filteredProjects);
                return _FilteredProjects;
            }
            else
            {
                await PopulateProjectsAsync(cancellationToken);
                return _FilteredProjects;
            }
        }

        public async Task<ListMilestoneData> GetAllMilestones(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_Milestones.MilestoneData.Any())
            {
                return _Milestones;
            }
            else
            {
                await PopulateMilestonesAsync(cancellationToken);
                return _Milestones;
            }
        }

        public async Task<ListMilestoneData> GetMilestonesById(string id ,CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_Milestones.MilestoneData.Any())
            {
                _FilteredMilestones.MilestoneData.Clear();
                List<MilestoneData> filteredMilestones = _Milestones.MilestoneData.Where(x => x.Id == id).ToList();
                _FilteredMilestones.MilestoneData.AddRange(filteredMilestones);
                return _FilteredMilestones;
            }
            else
            {
                await PopulateMilestonesAsync(cancellationToken);
                return _FilteredMilestones;
            }
        }

        #endregion

        #region Vehicle

        public async Task<ListVehicleData> GetAllVehicles(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_Vehicles.VehicleData.Any())
            {
                return _Vehicles;
            }
            else
            {
                await PopulateVehiclesAsync(cancellationToken);
                return _Vehicles;
            }
        }

        public async Task<ListVehicleData> GetVehiclesById(string id, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_Vehicles.VehicleData.Any())
            {
                _FilteredVehicles.VehicleData.Clear();
                List<VehicleData> filteredVehicles = _Vehicles.VehicleData.Where(x => x.Id == id).ToList();
                _FilteredVehicles.VehicleData.AddRange(filteredVehicles);
                return _FilteredVehicles;
            }
            else
            {
                await PopulateVehiclesAsync(cancellationToken);
                return _FilteredVehicles;
            }
        }

        public async Task<ListVehicleData> GetVehiclesByDisplay(string vehicleDisplay , CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_Vehicles.VehicleData.Any())
            {
                _FilteredVehicles.VehicleData.Clear();
                List<VehicleData> filteredVehicles = _Vehicles.VehicleData.Where(x => x.VehicleDisplay == vehicleDisplay).ToList();
                _FilteredVehicles.VehicleData.AddRange(filteredVehicles);
                return _FilteredVehicles;
            }
            else
            {
                await PopulateVehiclesAsync(cancellationToken);
                return _FilteredVehicles;
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
                    _CurrencyHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetCurrenciesQuery, List<CurrencyData>>>();
                    _CurrencyRefreshInProgress = true;
                    GetCurrenciesQuery query = new GetCurrenciesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<CurrencyData>> results = await _CurrencyHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _Currencies.CurrencyData.Clear();
                        _Currencies.CurrencyData.AddRange(results.Value);
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
                    _CustomerHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetAllCustomerBusinessUnitsQuery, List<CustomerData>>>();
                    _CustomerRefreshInProgress = true;
                    GetAllCustomerBusinessUnitsQuery query = new GetAllCustomerBusinessUnitsQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<CustomerData>> results = await _CustomerHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _Customers.CustomerData.Clear();
                        _Customers.CustomerData.AddRange(results.Value);
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
                    _CustomerLocationHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetAllCustomerLocationsQuery, List<CustomerLocationData>>>();
                    _CustomerLocationRefreshInProgress = true;
                    GetAllCustomerLocationsQuery query = new GetAllCustomerLocationsQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<CustomerLocationData>> results = await _CustomerLocationHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _CustomerLocations.CustomerLocationData.Clear();
                        _CustomerLocations.CustomerLocationData.AddRange(results.Value);
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
                    _CustomerProjectAssociationsHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetAllCustomerProjectAssociationsQuery, List<CustomerProjectAssociationData>>>();
                    _CustomerProjectAssociationsRefreshInProgress = true;
                    GetAllCustomerProjectAssociationsQuery query = new GetAllCustomerProjectAssociationsQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<CustomerProjectAssociationData>> results = await _CustomerProjectAssociationsHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _CustomerProjectAssociations.CustomerProjectAssociationData.Clear();
                        _CustomerProjectAssociations.CustomerProjectAssociationData.AddRange(results.Value);
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
                    _CustomerSalesEntitiesHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetAllCustomerSalesEntitiesQuery, List <CustomerSalesEntityData>>>();
                    _CustomerSalesEntitiesRefreshInProgress = true;
                    GetAllCustomerSalesEntitiesQuery query = new GetAllCustomerSalesEntitiesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<CustomerSalesEntityData>> results = await _CustomerSalesEntitiesHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _CustomerSalesEntities.CustomerSalesEntityData.Clear();
                        _CustomerSalesEntities.CustomerSalesEntityData.AddRange(results.Value);
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
                    _CustomerBusinessUserAssociationsHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetCustomerBusinessUserAssociationsQuery, List<CustomerBusinessUserAssociationData>>>();
                    _CustomerBusinessUserAssociationsRefreshInProgress = true;
                    GetCustomerBusinessUserAssociationsQuery query = new GetCustomerBusinessUserAssociationsQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<CustomerBusinessUserAssociationData>> results = await _CustomerBusinessUserAssociationsHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _CustomerBusinessUserAssociations.CustomerBusinessUserAssociationData.Clear();
                        _CustomerBusinessUserAssociations.CustomerBusinessUserAssociationData.AddRange(results.Value);
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
                    _PlatformHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetAllPlatformHierarchiesQuery, List<PlatformData>>>();
                    _PlatformRefreshInProgress = true;
                    GetAllPlatformHierarchiesQuery query = new GetAllPlatformHierarchiesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<PlatformData>> results = await _PlatformHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _Platforms.PlatformData.Clear();
                        _Platforms.PlatformData.AddRange(results.Value);
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
                    _ProgramHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetAllProgramHierarchiesQuery, List<ProgramData>>>();
                    _ProgramRefreshInProgress = true;
                    GetAllProgramHierarchiesQuery query = new GetAllProgramHierarchiesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<ProgramData>> results = await _ProgramHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _Programs.ProgramData.Clear();
                        _Programs.ProgramData.AddRange(results.Value);
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
                    _ProjectHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetAllProjectHierarchiesQuery, List<ProjectData>>>();
                    _ProjectRefreshInProgress = true;
                    GetAllProjectHierarchiesQuery query = new GetAllProjectHierarchiesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<ProjectData>> results = await _ProjectHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _Projects.ProjectData.Clear();
                        _Projects.ProjectData.AddRange(results.Value);
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
                    _MilestoneHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetAllMilestoneHierarchiesQuery, List<MilestoneData>>>();
                    _MilestoneRefreshInProgress = true;
                    GetAllMilestoneHierarchiesQuery query = new GetAllMilestoneHierarchiesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<MilestoneData>> results = await _MilestoneHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _Milestones.MilestoneData.Clear();
                        _Milestones.MilestoneData.AddRange(results.Value);
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
                    _VehicleHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetAllVehiclesQuery, List<VehicleData>>>();
                    _VehicleRefreshInProgress = true;
                    GetAllVehiclesQuery query = new GetAllVehiclesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<VehicleData>> results = await _VehicleHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _Vehicles.VehicleData.Clear();
                        _Vehicles.VehicleData.AddRange(results.Value);
                    }

                    _VehicleRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        #endregion

        #endregion

        void PopulateSampleData()
        {
            _Currencies = SampleMasterDataService.PopulateCurrencyData();
            _Customers = SampleMasterDataService.PopulateCustomerData();
            _CustomerLocations = SampleMasterDataService.PopulateCustomerLocationsData();
            _CustomerSalesEntities = SampleMasterDataService.PopulateCustomerSalesEntityData();
            _CustomerProjectAssociations = SampleMasterDataService.PopulateCustomerProjectAssociationData();
            _CustomerBusinessUserAssociations = SampleMasterDataService.PopulateCustomerBusinessUserAssociationData();
            _Platforms = SampleMasterDataService.PopulatePlatformData();
            _Programs = SampleMasterDataService.PopulateProgramData();
            _Projects = SampleMasterDataService.PopulateProjectData();
            _Milestones = SampleMasterDataService.PopulateMilestoneData();
            _Vehicles = SampleMasterDataService.PopulateVehicleData();
        }
    }
}
