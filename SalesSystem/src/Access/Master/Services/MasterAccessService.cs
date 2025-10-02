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

            _ServiceProvider = serviceProvider;

            if (testing)
            {
                PopulateSampleData();
            }
        }
        #endregion

        #region Handlers

        #region Currency

        public async Task<ListCurrencyGrpc> GetAllCurrencies(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_Currencies.CurrencyGrpc.Any())
            {
                return _Currencies;
            }
            else
            {
                await PopulateCurrenciesAsync(cancellationToken);
                return _Currencies;
            }
        }

        public async Task<ListCurrencyGrpc> GetCurrenciesById(string id ,CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_Currencies.CurrencyGrpc.Any())
            {
                _FilteredCurrencies.CurrencyGrpc.Clear();
                List<CurrencyGrpc> filteredList = _Currencies.CurrencyGrpc.Where(x => x.Id == id).ToList();
                _FilteredCurrencies.CurrencyGrpc.AddRange(filteredList);
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

        public async Task<ListCustomerGrpc> GetAllCustomerBusinessUnits(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_Customers.CustomerGrpc.Any())
            {
                return _Customers;
            }
            else
            {
                await PopulateCustomersAsync(cancellationToken);
                return _Customers;
            }
        }

        public async Task<ListCustomerGrpc> GetCustomerBusinessUnitsById(string id, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            _FilteredCustomers.CustomerGrpc.Clear();
            if (_Customers.CustomerGrpc.Any() && _CustomerBusinessUserAssociations.CustomerBusinessUserAssociationGrpc.Any())
            {
                CustomerBusinessUserAssociationGrpc? userAssociation = _CustomerBusinessUserAssociations.CustomerBusinessUserAssociationGrpc.Where(x => x.UserGuid == id).FirstOrDefault();
                if(userAssociation == null || userAssociation.CustomerBusinessHierarchyList == null)
                {
                    return _FilteredCustomers;
                }

                List<CustomerBuisnessHirarchyListDto>? associatedCustomers = JsonConvert.DeserializeObject<List<CustomerBuisnessHirarchyListDto>>(userAssociation.CustomerBusinessHierarchyList);
                if (associatedCustomers == null)
                {
                    return _FilteredCustomers;
                }

                foreach (CustomerBuisnessHirarchyListDto customer in associatedCustomers)
                {
                    if (customer.IsActive == true)
                    {
                        List<CustomerGrpc> filteredCustomers = _Customers.CustomerGrpc.Where(x => x.Id == customer.CustomerBusinessHierarchyGuid.ToString()).ToList();
                        _FilteredCustomers.CustomerGrpc.AddRange(filteredCustomers);
                    }
                }

                return _FilteredCustomers;
            }
            else
            {
                await PopulateCustomersAsync(cancellationToken);
                return _FilteredCustomers;
            }
        }

        public async Task<ListCustomerLocationGrpc> GetAllCustomerLocations(CancellationToken cancellationToken)
        {
            await Task.Delay(0, cancellationToken);
            if (_CustomerLocations.CustomerLocationGrpc.Any())
            {
                return _CustomerLocations;
            }
            else
            {
                await PopulateCustomerLocationsAsync(cancellationToken);
                return _CustomerLocations;
            }
        }

        public async Task<ListCustomerLocationGrpc> GetCustomerLocationsById(string id ,CancellationToken cancellationToken)
        {
            await Task.Delay(0, cancellationToken);
            _FilteredLocations.CustomerLocationGrpc.Clear();
            if (_CustomerLocations.CustomerLocationGrpc.Any())
            {
                List<CustomerLocationGrpc> filteredLocations = _CustomerLocations.CustomerLocationGrpc.Where(x => x.Id == id).ToList();
                _FilteredLocations.CustomerLocationGrpc.AddRange(filteredLocations);
                return _FilteredLocations;
            }
            else
            {
                await PopulateCustomerLocationsAsync(cancellationToken);
                return _FilteredLocations;
            }
        }

        public async Task<ListCustomerLocationGrpc> GetCustomerLocationsByUserId(string userId ,CancellationToken cancellationToken)
        {
            await Task.Delay(0, cancellationToken);
            _FilteredLocations.CustomerLocationGrpc.Clear();
            if (_CustomerLocations.CustomerLocationGrpc.Any() && _CustomerBusinessUserAssociations.CustomerBusinessUserAssociationGrpc.Any())
            {
                CustomerBusinessUserAssociationGrpc? user = _CustomerBusinessUserAssociations.CustomerBusinessUserAssociationGrpc.Where(x => x.UserGuid == userId).FirstOrDefault();
                if (user != null)
                {
                    if (user.CustomerBusinessHierarchyList != null)
                    {
                        List<CustomerLocationGrpc>? userLocations = JsonConvert.DeserializeObject<List<CustomerLocationGrpc>>(user.CustomerBusinessHierarchyList);
                        if (userLocations != null)
                        {
                            foreach (CustomerLocationGrpc location in userLocations)
                            {
                                if (location.IsActive == true)
                                {
                                    List<CustomerLocationGrpc> filteredLocations = _CustomerLocations.CustomerLocationGrpc.Where(x => x.CustomerBusinessHierarchyGuid == location.CustomerBusinessHierarchyGuid).ToList();
                                    _FilteredLocations.CustomerLocationGrpc.AddRange(filteredLocations);
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

        public async Task<ListCustomerLocationGrpc> GetCustomerLocationsByCustomerId(string customerId ,CancellationToken cancellationToken)
        {
            await Task.Delay(0, cancellationToken);
            _FilteredLocations.CustomerLocationGrpc.Clear();
            if (_CustomerLocations.CustomerLocationGrpc.Any())
            {
                List<CustomerLocationGrpc> filteredLocations = _CustomerLocations.CustomerLocationGrpc.Where(x => x.CustomerBusinessHierarchyGuid == customerId).ToList();
                _FilteredLocations.CustomerLocationGrpc.AddRange(filteredLocations);
                return _FilteredLocations;
            }
            else
            {
                await PopulateCustomerLocationsAsync(cancellationToken);
                return _FilteredLocations;
            }
        }   

        public async Task<ListCustomerProjectAssociationGrpc> GetAllCustomerProjectAssociations(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_CustomerProjectAssociations.CustomerProjectAssociationGrpc.Any())
            {
                return _CustomerProjectAssociations;
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
                CustomerBusinessUserAssociationGrpc? user = GetCustomerBusinessUserAssociationsByUserId(userId, cancellationToken).Result.CustomerBusinessUserAssociationGrpc.FirstOrDefault();
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
                                        List<CustomerLocationGrpc> filteredLocations = _CustomerLocations.CustomerLocationGrpc.Where(x => x.CustomerBusinessHierarchyGuid == customer.CustomerBusinessHierarchyGuid).ToList();
                                        _FilteredLocations.CustomerLocationGrpc.AddRange(filteredLocations);
                                        foreach (CustomerLocationGrpc customerLocation in _FilteredLocations.CustomerLocationGrpc)
                                        {
                                            List<CustomerProjectAssociationGrpc> customerProjects = _CustomerProjectAssociations.CustomerProjectAssociationGrpc.Where(x => x.CustomerLocationGuid == customerLocation.Id).ToList();
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

        public async Task<ListCustomerProjectAssociationGrpc> GetCustomerProjectAssociationsByLocationId(string locationId ,CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            _FilteredCustomerProjectAssociations.CustomerProjectAssociationGrpc.Clear();
            if (_CustomerProjectAssociations.CustomerProjectAssociationGrpc.Any())
            {
                List<CustomerProjectAssociationGrpc> filteredProjects = _CustomerProjectAssociations.CustomerProjectAssociationGrpc.Where(x => x.CustomerLocationGuid == locationId).ToList();
                _FilteredCustomerProjectAssociations.CustomerProjectAssociationGrpc.AddRange(filteredProjects);
                return _FilteredCustomerProjectAssociations;
            }
            else
            {
                await PopulateCustomerProjectAssociationsAsync(cancellationToken);
                return _FilteredCustomerProjectAssociations;
            }
        }   

        public async Task<ListCustomerSalesEntityGrpc> GetAllCustomerSalesEntities(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_CustomerSalesEntities.CustomerSalesEntityGrpc.Any())
            {
                return _CustomerSalesEntities;
            }
            else
            {
                await PopulateCustomerSalesEntitiesAsync(cancellationToken);
                return _CustomerSalesEntities;
            }
        }

        public async Task<ListCustomerSalesEntityGrpc> GetAllCustomerSalesByUserIdEntities(string userId ,CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            _FilteredCustomerSalesEntities.CustomerSalesEntityGrpc.Clear();
            if (_CustomerSalesEntities.CustomerSalesEntityGrpc.Any())
            {
                ListCustomerLocationGrpc locations = await GetCustomerLocationsByUserId(userId, cancellationToken);
                foreach(CustomerLocationGrpc location in locations.CustomerLocationGrpc)
                {
                    List<CustomerSalesEntityGrpc> salesByLocation = _CustomerSalesEntities.CustomerSalesEntityGrpc.Where(x => x.CustomerHierarchyGuid == location.Id).ToList();
                    _FilteredCustomerSalesEntities.CustomerSalesEntityGrpc.AddRange(salesByLocation);
                }

                return _FilteredCustomerSalesEntities;
            }
            else
            {
                await PopulateCustomerSalesEntitiesAsync(cancellationToken);
                return _FilteredCustomerSalesEntities;
            }
        }

        public async Task<ListCustomerBusinessUserAssociationGrpc> GetCustomerBusinessUserAssociations(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_CustomerBusinessUserAssociations.CustomerBusinessUserAssociationGrpc.Any())
            {
                return _CustomerBusinessUserAssociations;
            }
            else
            {
                await PopulateCustomerBusinessUserAssociationsAsync(cancellationToken);
                return _CustomerBusinessUserAssociations;
            }
        }
        public async Task<ListCustomerBusinessUserAssociationGrpc> GetCustomerBusinessUserAssociationsByUserId(string userId, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            _FilteredCustomerBusinessUserAssociations.CustomerBusinessUserAssociationGrpc.Clear();
            if (_CustomerBusinessUserAssociations.CustomerBusinessUserAssociationGrpc.Any())
            {
                List<CustomerBusinessUserAssociationGrpc> filteredCustomerBusinessUserAssociationGrpc = _CustomerBusinessUserAssociations.CustomerBusinessUserAssociationGrpc.Where(x => x.UserGuid == userId).ToList();
                _FilteredCustomerBusinessUserAssociations.CustomerBusinessUserAssociationGrpc.AddRange(filteredCustomerBusinessUserAssociationGrpc);
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

        public async Task<ListPlatformGrpc> GetAllPlatforms(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_Platforms.PlatformGrpc.Any())
            {
                return _Platforms;
            }
            else
            {
                await PopulatePlatformsAsync(cancellationToken);
                return _Platforms;
            }
        }
        public async Task<ListPlatformGrpc> GetPlatformsById(string id ,CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_Platforms.PlatformGrpc.Any())
            {
                _FilteredPlatforms.PlatformGrpc.Clear();
                List<PlatformGrpc> filteredPlatforms = _Platforms.PlatformGrpc.Where(x => x.Id == id).ToList();
                _FilteredPlatforms.PlatformGrpc.AddRange(filteredPlatforms);
                return _FilteredPlatforms;
            }
            else
            {
                await PopulatePlatformsAsync(cancellationToken);
                return _FilteredPlatforms;
            }
        }

        public async Task<ListProgramGrpc> GetAllPrograms(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_Programs.ProgramGrpc.Any())
            {
                return _Programs;
            }
            else
            {
                await PopulateProgramsAsync(cancellationToken);
                return _Programs;
            }
        }
        public async Task<ListProgramGrpc> GetProgramsById(string id,CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_Programs.ProgramGrpc.Any())
            {
                _FilteredPrograms.ProgramGrpc.Clear();
                List<ProgramGrpc> filteredPrograms = _Programs.ProgramGrpc.Where(x => x.Id == id).ToList();
                _FilteredPrograms.ProgramGrpc.AddRange(filteredPrograms);
                return _FilteredPrograms;
            }
            else
            {
                await PopulateProgramsAsync(cancellationToken);
                return _FilteredPrograms;
            }
        }

        public async Task<ListProjectGrpc> GetAllProjects(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_Projects.ProjectGrpc.Any())
            {
                return _Projects;
            }
            else
            {
                await PopulateProjectsAsync(cancellationToken);
                return _Projects;
            }
        }

        public async Task<ListProjectGrpc> GetProjectsById(string id, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_Projects.ProjectGrpc.Any())
            {
                _FilteredProjects.ProjectGrpc.Clear();
                List<ProjectGrpc> filteredProjects = _Projects.ProjectGrpc.Where(x => x.Id == id).ToList();
                _FilteredProjects.ProjectGrpc.AddRange(filteredProjects);
                return _FilteredProjects;
            }
            else
            {
                await PopulateProjectsAsync(cancellationToken);
                return _FilteredProjects;
            }
        }

        public async Task<ListMilestoneGrpc> GetAllMilestones(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_Milestones.MilestoneGrpc.Any())
            {
                return _Milestones;
            }
            else
            {
                await PopulateMilestonesAsync(cancellationToken);
                return _Milestones;
            }
        }

        public async Task<ListMilestoneGrpc> GetMilestonesById(string id ,CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_Milestones.MilestoneGrpc.Any())
            {
                _FilteredMilestones.MilestoneGrpc.Clear();
                List<MilestoneGrpc> filteredMilestones = _Milestones.MilestoneGrpc.Where(x => x.Id == id).ToList();
                _FilteredMilestones.MilestoneGrpc.AddRange(filteredMilestones);
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

        public async Task<ListVehicleGrpc> GetAllVehicles(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_Vehicles.VehicleGrpc.Any())
            {
                return _Vehicles;
            }
            else
            {
                await PopulateVehiclesAsync(cancellationToken);
                return _Vehicles;
            }
        }

        public async Task<ListVehicleGrpc> GetVehiclesById(string id, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_Vehicles.VehicleGrpc.Any())
            {
                _FilteredVehicles.VehicleGrpc.Clear();
                List<VehicleGrpc> filteredVehicles = _Vehicles.VehicleGrpc.Where(x => x.Id == id).ToList();
                _FilteredVehicles.VehicleGrpc.AddRange(filteredVehicles);
                return _FilteredVehicles;
            }
            else
            {
                await PopulateVehiclesAsync(cancellationToken);
                return _FilteredVehicles;
            }
        }

        public async Task<ListVehicleGrpc> GetVehiclesByDisplay(string vehicleDisplay , CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_Vehicles.VehicleGrpc.Any())
            {
                _FilteredVehicles.VehicleGrpc.Clear();
                List<VehicleGrpc> filteredVehicles = _Vehicles.VehicleGrpc.Where(x => x.VehicleDisplay == vehicleDisplay).ToList();
                _FilteredVehicles.VehicleGrpc.AddRange(filteredVehicles);
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

        #endregion

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
        }
    }
}
