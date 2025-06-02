
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Master.Services
{
    /// <summary>
    /// This class is used to make calls to the database queries and to hold the data dictionaries.
    /// It is used by both the Grpc and Http api services
    /// </summary>
    sealed class MasterAccessService : IMasterAccessService
    {
        #region In Memory Datasets

        #region Currency

        List<CurrencyDto> _Currencies;
        List<CurrencyDto> _FilteredCurrencies;

        #endregion

        #region Customer

        List<CustomerBusinessHierarchyDto> _Customers;
        List<CustomerBusinessHierarchyDto> _FilteredCustomers;
        List<CustomerHierarchyDto> _CustomerLocations;
        List<CustomerHierarchyDto> _FilteredLocations;
        List<CustomerSalesEntityDto> _CustomerSalesEntities;
        List<CustomerSalesEntityDto> _FilteredCustomerSalesEntities;
        List<CustomerProjectAssociationDto> _CustomerProjectAssociations;
        List<CustomerProjectAssociationDto> _FilteredCustomerProjectAssociations;
        List<CustomerBusinessUserAssociationDto> _CustomerBusinessUserAssociations;
        List<CustomerBusinessUserAssociationDto> _FilteredCustomerBusinessUserAssociations;

        #endregion

        #region Project

       List<PlatformHierarchyDto> _Platforms;
        List<ProgramHierarchyDto> _Programs;
        List<ProjectHierarchyDto> _Projects;
        List<MilestoneHierarchyDto> _Milestones;

        #endregion

        #region Vehicle

        List<VehicleDto> _Vehicles;

        #endregion

        #endregion

        #region Fields and Properties

        #region Currency

        IQueryHandler<GetCurrenciesQuery, List<CurrencyDto>>? _CurrencyHandler;
        bool _CurrencyRefreshInProgress;

        #endregion

        #region Customer

        IQueryHandler<GetAllCustomerBusinessUnitsQuery, List<CustomerBusinessHierarchyDto>>? _CustomerHandler;
        IQueryHandler<GetAllCustomerLocationsQuery, List<CustomerHierarchyDto>>? _CustomerLocationHandler;
        IQueryHandler<GetAllCustomerProjectAssociationsQuery, List<CustomerProjectAssociationDto>>? _CustomerProjectAssociationsHandler;
        IQueryHandler<GetAllCustomerSalesEntitiesQuery, List<CustomerSalesEntityDto>>? _CustomerSalesEntitiesHandler;
        IQueryHandler<GetCustomerBusinessUserAssociationsQuery, List<CustomerBusinessUserAssociationDto>>? _CustomerBusinessUserAssociationsHandler;
        bool _CustomerRefreshInProgress;
        bool _CustomerLocationRefreshInProgress;
        bool _CustomerProjectAssociationsRefreshInProgress;
        bool _CustomerSalesEntitiesRefreshInProgress;
        bool _CustomerBusinessUserAssociationsRefreshInProgress;

        #endregion

        #region Project

        IQueryHandler<GetAllPlatformHierarchiesQuery, List<PlatformHierarchyDto>>? _PlatformHandler;
        IQueryHandler<GetAllProgramHierarchiesQuery, List<ProgramHierarchyDto>>? _ProgramHandler;
        IQueryHandler<GetAllProjectHierarchiesQuery, List<ProjectHierarchyDto>>? _ProjectHandler;
        IQueryHandler<GetAllMilestoneHierarchiesQuery, List<MilestoneHierarchyDto>>? _MilestoneHandler;
        bool _PlatformRefreshInProgress;
        bool _ProgramRefreshInProgress;
        bool _ProjectRefreshInProgress;
        bool _MilestoneRefreshInProgress;

        #endregion

        #region Vehicle

        IQueryHandler<GetAllVehiclesQuery, List<VehicleDto>>? _VehicleHandler;
        bool _VehicleRefreshInProgress;

        #endregion

        readonly IServiceProvider _ServiceProvider;

        #endregion

        #region Constructor
        public MasterAccessService(IServiceProvider serviceProvider)
        {
            #region Currency

            _Currencies = [];
            _FilteredCurrencies = [];
            _CurrencyRefreshInProgress = false;

            #endregion

            #region Customer

            _Customers = [];
            _FilteredCustomers = [];
            _CustomerLocations = [];
            _FilteredLocations = [];
            _CustomerSalesEntities = [];
            _FilteredCustomerSalesEntities = [];
            _CustomerProjectAssociations = [];
            _FilteredCustomerProjectAssociations = [];
            _CustomerBusinessUserAssociations = [];
            _FilteredCustomerBusinessUserAssociations = [];
            _CustomerRefreshInProgress = false;
            _CustomerLocationRefreshInProgress = false;
            _CustomerProjectAssociationsRefreshInProgress = false;
            _CustomerSalesEntitiesRefreshInProgress = false;
            _CustomerBusinessUserAssociationsRefreshInProgress = false;

            #endregion

            #region Project

            _Platforms = [];
            _Programs = [];
            _Projects = [];
            _Milestones = [];
            
            _PlatformRefreshInProgress = false;
            _ProgramRefreshInProgress = false;
            _ProjectRefreshInProgress = false;
            _MilestoneRefreshInProgress = false;

            #endregion

            #region Vehicle

            _Vehicles = [];
            _VehicleRefreshInProgress = false;

            #endregion

            _ServiceProvider = serviceProvider;
        }

        #endregion

        #region Handlers

        #region Currency

        public async Task<Result<List<CurrencyDto>>> GetAllCurrencies(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_Currencies.Any())
            {
                return _Currencies;
            }
            else
            {
                await PopulateCurrenciesAsync(cancellationToken);
                return _Currencies;
            }
        }

        public async Task<Result<List<CurrencyDto>>> GetCurrenciesById(Guid id ,CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_Currencies.Any())
            {
                _FilteredCurrencies.Clear();
                _FilteredCurrencies = _Currencies.Where(x => x.Id == id).ToList();
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

        public async Task<Result<List<CustomerBusinessHierarchyDto>>> GetAllCustomerBusinessUnits(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_Customers.Any())
            {
                return _Customers;
            }
            else
            {
                await PopulateCustomersAsync(cancellationToken);
                return _Customers;
            }
        }

        public async Task<Result<List<CustomerBusinessHierarchyDto>>> GetCustomerBusinessUnitsById(Guid id, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            _FilteredCustomers.Clear();
            if (_Customers.Any())
            {
                _FilteredCustomers = _Customers.Where(x => x.Id == id).ToList();
                return _FilteredCustomers;
            }
            else
            {
                await PopulateCustomersAsync(cancellationToken);
                return _FilteredCustomers;
            }
        }

        public async Task<Result<List<CustomerHierarchyDto>>> GetAllCustomerLocations(CancellationToken cancellationToken)
        {
            await Task.Delay(0, cancellationToken);
            if (_CustomerLocations.Any())
            {
                return _CustomerLocations;
            }
            else
            {
                await PopulateCustomerLocationsAsync(cancellationToken);
                return _CustomerLocations;
            }
        }

        public async Task<Result<List<CustomerHierarchyDto>>> GetCustomerLocationsById(Guid id ,CancellationToken cancellationToken)
        {
            await Task.Delay(0, cancellationToken);
            _FilteredLocations.Clear();
            if (_CustomerLocations.Any())
            {
                _FilteredLocations = _CustomerLocations.Where(x => x.Id == id).ToList();
                return _FilteredLocations;
            }
            else
            {
                await PopulateCustomerLocationsAsync(cancellationToken);
                return _FilteredLocations;
            }
        }

        public async Task<Result<List<CustomerHierarchyDto>>> GetCustomerLocationsByUserId(Guid userId ,CancellationToken cancellationToken)
        {
            await Task.Delay(0, cancellationToken);
            _FilteredLocations.Clear();
            if (_CustomerLocations.Any() && _CustomerBusinessUserAssociations.Any())
            {
                CustomerBusinessUserAssociationDto user = _CustomerBusinessUserAssociations.Where(x => x.UserGuid == userId).First();
                if (user.CustomerBusinessHierarchyList != null)
                {
                    List<CustomerHierarchyDto>? userLocations = JsonConvert.DeserializeObject<List<CustomerHierarchyDto>>(user.CustomerBusinessHierarchyList);
                    if (userLocations != null)
                    {
                        foreach (CustomerHierarchyDto location in userLocations)
                        {
                            if (location.IsActive == true)
                            {
                                _FilteredLocations = _CustomerLocations.Where(x => x.CustomerBusinessHierarchyGuid == location.CustomerBusinessHierarchyGuid).ToList();
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

        public async Task<Result<List<CustomerProjectAssociationDto>>> GetAllCustomerProjectAssociations(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_CustomerProjectAssociations.Any())
            {
                return _CustomerProjectAssociations;
            }
            else
            {
                await PopulateCustomerProjectAssociationsAsync(cancellationToken);
                return _CustomerProjectAssociations;
            }
        }

        public async Task<Result<List<CustomerProjectAssociationDto>>> GetAllCustomerProjectAssociationsByUserId(Guid userId ,CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            _FilteredLocations.Clear();
            if (_CustomerProjectAssociations.Any() && _CustomerBusinessUserAssociations.Any())
            {
                CustomerBusinessUserAssociationDto user = GetCustomerBusinessUserAssociationsByUserId(userId, cancellationToken).Result.Value.First();
                if(user.CustomerBusinessHierarchyList != null)
                {
                    List<CustomerHierarchyDto>? userLocations = JsonConvert.DeserializeObject<List<CustomerHierarchyDto>>(user.CustomerBusinessHierarchyList);
                    if (userLocations != null) 
                    {
                        foreach (CustomerHierarchyDto location in userLocations)
                        {
                            if (location.IsActive == true)
                            {
                                if (location.CustomerBusinessHierarchyGuid != null)
                                {
                                    _FilteredLocations = _CustomerLocations.Where(x => x.CustomerBusinessHierarchyGuid == location.CustomerBusinessHierarchyGuid).ToList();
                                    foreach(CustomerHierarchyDto customerLocation in _FilteredLocations)
                                    {
                                        List<CustomerProjectAssociationDto> customerProjects = _CustomerProjectAssociations.Where(x => x.CustomerLocationGuid == customerLocation.Id).ToList();
                                        _FilteredCustomerProjectAssociations.AddRange(customerProjects);
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

        public async Task<Result<List<CustomerSalesEntityDto>>> GetAllCustomerSalesEntities(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_CustomerSalesEntities.Any())
            {
                return _CustomerSalesEntities;
            }
            else
            {
                await PopulateCustomerSalesEntitiesAsync(cancellationToken);
                return _CustomerSalesEntities;
            }
        }

        public async Task<Result<List<CustomerSalesEntityDto>>> GetAllCustomerSalesByUserIdEntities(Guid userId ,CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            _FilteredCustomerSalesEntities.Clear();
            if (_CustomerSalesEntities.Any())
            {
                Result<List<CustomerHierarchyDto>> locations = await GetCustomerLocationsByUserId(userId, cancellationToken);
                foreach(CustomerHierarchyDto location in locations.Value)
                {
                    List<CustomerSalesEntityDto> salesByLocation = _CustomerSalesEntities.Where(x => x.CustomerHierarchyGuid == location.Id).ToList();
                    _FilteredCustomerSalesEntities.AddRange(salesByLocation);
                }

                return _FilteredCustomerSalesEntities;
            }
            else
            {
                await PopulateCustomerSalesEntitiesAsync(cancellationToken);
                return _FilteredCustomerSalesEntities;
            }
        }

        public async Task<Result<List<CustomerBusinessUserAssociationDto>>> GetCustomerBusinessUserAssociations(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_CustomerBusinessUserAssociations.Any())
            {
                return _CustomerBusinessUserAssociations;
            }
            else
            {
                await PopulateCustomerBusinessUserAssociationsAsync(cancellationToken);
                return _CustomerBusinessUserAssociations;
            }
        }
        public async Task<Result<List<CustomerBusinessUserAssociationDto>>> GetCustomerBusinessUserAssociationsByUserId(Guid userId, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            _FilteredCustomerBusinessUserAssociations.Clear();
            if (_CustomerBusinessUserAssociations.Any())
            {
                _FilteredCustomerBusinessUserAssociations = _CustomerBusinessUserAssociations.Where(x => x.UserGuid == userId).ToList();
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

        public async Task<Result<List<PlatformHierarchyDto>>> GetAllPlatforms(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_Platforms.Any())
            {
                return _Platforms;
            }
            else
            {
                await PopulatePlatformsAsync(cancellationToken);
                return _Platforms;
            }
        }

        public async Task<Result<List<ProgramHierarchyDto>>> GetAllPrograms(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_Programs.Any())
            {
                return _Programs;
            }
            else
            {
                await PopulateProgramsAsync(cancellationToken);
                return _Programs;
            }
        }

        public async Task<Result<List<ProjectHierarchyDto>>> GetAllProjects(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_Projects.Any())
            {
                return _Projects;
            }
            else
            {
                await PopulateProjectsAsync(cancellationToken);
                return _Projects;
            }
        }

        public async Task<Result<List<MilestoneHierarchyDto>>> GetAllMilestones(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_Milestones.Any())
            {
                return _Milestones;
            }
            else
            {
                await PopulateMilestonesAsync(cancellationToken);
                return _Milestones;
            }
        }

        #endregion

        #region Vehicle

        public async Task<Result<List<VehicleDto>>> GetAllVehicles(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_Vehicles.Any())
            {
                return _Vehicles;
            }
            else
            {
                await PopulateVehiclesAsync(cancellationToken);
                return _Vehicles;
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
                    _CurrencyHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetCurrenciesQuery, List<CurrencyDto>>>();
                    _CurrencyRefreshInProgress = true;
                    GetCurrenciesQuery query = new GetCurrenciesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<CurrencyDto>> results = await _CurrencyHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _Currencies.Clear();
                        _Currencies = results.Value;
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
                    _CustomerHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetAllCustomerBusinessUnitsQuery, List<CustomerBusinessHierarchyDto>>>();
                    _CustomerRefreshInProgress = true;
                    GetAllCustomerBusinessUnitsQuery query = new GetAllCustomerBusinessUnitsQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<CustomerBusinessHierarchyDto>> results = await _CustomerHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _Customers.Clear();
                        _Customers = results.Value;
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
                    _CustomerLocationHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetAllCustomerLocationsQuery, List<CustomerHierarchyDto>>>();
                    _CustomerLocationRefreshInProgress = true;
                    GetAllCustomerLocationsQuery query = new GetAllCustomerLocationsQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<CustomerHierarchyDto>> results = await _CustomerLocationHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _CustomerLocations.Clear();
                        _CustomerLocations = results.Value;
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
                    _CustomerProjectAssociationsHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetAllCustomerProjectAssociationsQuery, List<CustomerProjectAssociationDto>>>();
                    _CustomerProjectAssociationsRefreshInProgress = true;
                    GetAllCustomerProjectAssociationsQuery query = new GetAllCustomerProjectAssociationsQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<CustomerProjectAssociationDto>> results = await _CustomerProjectAssociationsHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _CustomerProjectAssociations.Clear();
                        _CustomerProjectAssociations = results.Value;
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
                    _CustomerSalesEntitiesHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetAllCustomerSalesEntitiesQuery, List <CustomerSalesEntityDto>>>();
                    _CustomerSalesEntitiesRefreshInProgress = true;
                    GetAllCustomerSalesEntitiesQuery query = new GetAllCustomerSalesEntitiesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<CustomerSalesEntityDto>> results = await _CustomerSalesEntitiesHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _CustomerSalesEntities.Clear();
                        _CustomerSalesEntities = results.Value;
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
                    _CustomerBusinessUserAssociationsHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetCustomerBusinessUserAssociationsQuery, List<CustomerBusinessUserAssociationDto>>>();
                    _CustomerBusinessUserAssociationsRefreshInProgress = true;
                    GetCustomerBusinessUserAssociationsQuery query = new GetCustomerBusinessUserAssociationsQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<CustomerBusinessUserAssociationDto>> results = await _CustomerBusinessUserAssociationsHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _CustomerBusinessUserAssociations.Clear();
                        _CustomerBusinessUserAssociations = results.Value;
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
                    _PlatformHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetAllPlatformHierarchiesQuery, List<PlatformHierarchyDto>>>();
                    _PlatformRefreshInProgress = true;
                    GetAllPlatformHierarchiesQuery query = new GetAllPlatformHierarchiesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<PlatformHierarchyDto>> results = await _PlatformHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _Platforms.Clear();
                        _Platforms = results.Value;
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
                    _ProgramHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetAllProgramHierarchiesQuery, List<ProgramHierarchyDto>>>();
                    _ProgramRefreshInProgress = true;
                    GetAllProgramHierarchiesQuery query = new GetAllProgramHierarchiesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<ProgramHierarchyDto>> results = await _ProgramHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _Programs.Clear();
                        _Programs = results.Value;
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
                    _ProjectHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetAllProjectHierarchiesQuery, List<ProjectHierarchyDto>>>();
                    _ProjectRefreshInProgress = true;
                    GetAllProjectHierarchiesQuery query = new GetAllProjectHierarchiesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<ProjectHierarchyDto>> results = await _ProjectHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _Projects.Clear();
                        _Projects = results.Value;
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
                    _MilestoneHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetAllMilestoneHierarchiesQuery, List<MilestoneHierarchyDto>>>();
                    _MilestoneRefreshInProgress = true;
                    GetAllMilestoneHierarchiesQuery query = new GetAllMilestoneHierarchiesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<MilestoneHierarchyDto>> results = await _MilestoneHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _Milestones.Clear();
                        _Milestones = results.Value;
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
                    _VehicleHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetAllVehiclesQuery, List<VehicleDto>>>();
                    _VehicleRefreshInProgress = true;
                    GetAllVehiclesQuery query = new GetAllVehiclesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<VehicleDto>> results = await _VehicleHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _Vehicles.Clear();
                        _Vehicles = results.Value;
                    }

                    _VehicleRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        #endregion

        #endregion
    }
}
