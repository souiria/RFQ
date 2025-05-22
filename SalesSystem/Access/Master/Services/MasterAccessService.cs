using Master.CQRS.Handler.Currency;
using System.Collections.Generic;

namespace Master.Services
{
    /// <summary>
    /// This class is used to make calls to the database queries and to hold the data dictionaries.
    /// It is used by both the Grpc and Http api services
    /// </summary>
    sealed class MasterAccessService : IMasterAccessService
    {
        #region In Memory Datasets

        List<CurrencyDto> _Currencies;
        List<CustomerBusinessHierarchyDto> _Customers;
        List<CustomerHierarchyDto> _CustomerLocations;
        List<CustomerSalesEntityDto> _CustomerSalesEntities;
        List<CustomerProjectAssociationDto> _CustomerProjectAssociations;
        List<CustomerBusinessUserAssociationDto> _CustomerBusinessUserAssociations;

        #endregion

        #region Fields and Properties

        IQueryHandler<GetCurrenciesQuery, List<CurrencyDto>>? _CurrencyHandler;
        IQueryHandler<GetAllCustomerBusinessUnitsQuery, List<CustomerBusinessHierarchyDto>>? _CustomerHandler;
        IQueryHandler<GetAllCustomerLocationsQuery, List<CustomerHierarchyDto>>? _CustomerLocationHandler;
        IQueryHandler<GetAllCustomerProjectAssociationsQuery, List<CustomerProjectAssociationDto>>? _CustomerProjectAssociationsHandler;
        IQueryHandler<GetAllCustomerSalesEntitiesQuery, List<CustomerSalesEntityDto>>? _CustomerSalesEntitiesHandler;
        IQueryHandler<GetCustomerBusinessUserAssociationsQuery, List<CustomerBusinessUserAssociationDto>>? _CustomerBusinessUserAssociationsHandler;
        readonly IServiceProvider _ServiceProvider;
        bool _CurrencyRefreshInProgress;
        bool _CustomerRefreshInProgress;
        bool _CustomerLocationRefreshInProgress;
        bool _CustomerProjectAssociationsRefreshInProgress;
        bool _CustomerSalesEntitiesRefreshInProgress;
        bool _CustomerBusinessUserAssociationsRefreshInProgress;

        #endregion

        #region Constructor
        public MasterAccessService(IServiceProvider serviceProvider)
        {
            _Currencies = [];
            _Customers = [];
            _CustomerLocations = [];
            _CustomerSalesEntities = [];
            _CustomerProjectAssociations = [];
            _CustomerBusinessUserAssociations = [];
            _CurrencyRefreshInProgress = false;
            _CustomerRefreshInProgress = false;
            _CustomerLocationRefreshInProgress = false;
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

        #endregion

        #region Project
        #endregion

        #region Vehicle
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
                    if (results.Value.Count > 0)
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
                    if (results.Value.Count > 0)
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
                    if (results.Value.Count > 0)
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
                    if (results.Value.Count > 0)
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
                    if (results.Value.Count > 0)
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
                    if (results.Value.Count > 0)
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

        #endregion
    }
}
