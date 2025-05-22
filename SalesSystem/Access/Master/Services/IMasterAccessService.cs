namespace Master.Services
{
    public interface IMasterAccessService
    {
        #region Currency
        Task<Result<List<CurrencyDto>>> GetAllCurrencies(CancellationToken cancellationToken);
        #endregion

        #region Customer

        Task<Result<List<CustomerBusinessHierarchyDto>>> GetAllCustomerBusinessUnits(CancellationToken cancellationToken);
        Task<Result<List<CustomerHierarchyDto>>> GetAllCustomerLocations(CancellationToken cancellationToken);
        Task<Result<List<CustomerProjectAssociationDto>>> GetAllCustomerProjectAssociations(CancellationToken cancellationToken);
        Task<Result<List<CustomerSalesEntityDto>>> GetAllCustomerSalesEntities(CancellationToken cancellationToken);
        Task<Result<List<CustomerBusinessUserAssociationDto>>> GetCustomerBusinessUserAssociations(CancellationToken cancellationToken);

        #endregion

        Task<bool> PopulateCurrenciesAsync(CancellationToken cancellationToken);
        Task<bool> PopulateCustomersAsync(CancellationToken cancellationToken);
        Task<bool> PopulateCustomerLocationsAsync(CancellationToken cancellationToken);
        Task<bool> PopulateCustomerProjectAssociationsAsync(CancellationToken cancellationToken);
        Task<bool> PopulateCustomerSalesEntitiesAsync(CancellationToken cancellationToken);
        Task<bool> PopulateCustomerBusinessUserAssociationsAsync(CancellationToken cancellationToken);
    }
}
