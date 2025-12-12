namespace Master.Services
{
    public interface IMasterAccessService
    {
        #region Currency
        Task<ListCurrencyGrpc> GetAllCurrencies(CancellationToken cancellationToken);
        Task<bool> PopulateCurrenciesAsync(CancellationToken cancellationToken);
        #endregion

        #region Customer

        Task<ListCustomerGrpc> GetAllCustomerBusinessUnits(CancellationToken cancellationToken);
        Task<bool> PopulateCustomersAsync(CancellationToken cancellationToken);
        Task<ListCustomerLocationGrpc> GetAllCustomerLocations(CancellationToken cancellationToken);
        Task<bool> PopulateCustomerLocationsAsync(CancellationToken cancellationToken);
        Task<ListCustomerProjectAssociationGrpc> GetAllCustomerProjectAssociations(CancellationToken cancellationToken);
        Task<ListCustomerProjectAssociationGrpc> GetAllCustomerProjectAssociationsByUserId(string userId,CancellationToken cancellationToken);
        Task<bool> PopulateCustomerProjectAssociationsAsync(CancellationToken cancellationToken);
        Task<ListCustomerSalesEntityGrpc> GetAllCustomerSalesEntities(CancellationToken cancellationToken);
        Task<bool> PopulateCustomerSalesEntitiesAsync(CancellationToken cancellationToken);
        Task<ListCustomerBusinessUserAssociationGrpc> GetCustomerBusinessUserAssociations(CancellationToken cancellationToken);
        Task<bool> PopulateCustomerBusinessUserAssociationsAsync(CancellationToken cancellationToken);

        #endregion

        #region Project

        Task<ListPlatformGrpc> GetAllPlatforms(CancellationToken cancellationToken);
        Task<bool> PopulatePlatformsAsync(CancellationToken cancellationToken);
        Task<ListProgramGrpc> GetAllPrograms(CancellationToken cancellationToken);
        Task<bool> PopulateProgramsAsync(CancellationToken cancellationToken);
        Task<ListProjectGrpc> GetAllProjects(CancellationToken cancellationToken);
        Task<bool> PopulateProjectsAsync(CancellationToken cancellationToken);
        Task<ListMilestoneGrpc> GetAllMilestones(CancellationToken cancellationToken);
        Task<bool> PopulateMilestonesAsync(CancellationToken cancellationToken);

        #endregion

        #region Vehicle

        Task<ListVehicleGrpc> GetAllVehicles(CancellationToken cancellationToken);
        Task<bool> PopulateVehiclesAsync(CancellationToken cancellationToken);

        #endregion

        Task HandleFilterCase<T>(string filterExpressionString, ParsingConfig parsingConfig,
            Action<IEnumerable<T>> setResponseCollection, CancellationToken cancellationToken);
    }
}
