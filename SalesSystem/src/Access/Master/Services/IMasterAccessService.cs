namespace Master.Services
{
    public interface IMasterAccessService
    {
        #region Currency
        Task<ListCurrencyGrpc> GetAllCurrencies(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<bool> PopulateCurrenciesAsync(CancellationToken cancellationToken);
        #endregion

        #region Customer

        Task<ListCustomerGrpc> GetAllCustomerBusinessUnits(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<bool> PopulateCustomersAsync(CancellationToken cancellationToken);
        Task<ListCustomerLocationGrpc> GetAllCustomerLocations(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<bool> PopulateCustomerLocationsAsync(CancellationToken cancellationToken);
        Task<ListCustomerProjectAssociationGrpc> GetAllCustomerProjectAssociations(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<ListCustomerProjectAssociationGrpc> GetAllCustomerProjectAssociationsByUserId(string userId,CancellationToken cancellationToken);
        Task<bool> PopulateCustomerProjectAssociationsAsync(CancellationToken cancellationToken);
        Task<ListCustomerSalesEntityGrpc> GetAllCustomerSalesEntities(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<bool> PopulateCustomerSalesEntitiesAsync(CancellationToken cancellationToken);
        Task<ListCustomerBusinessUserAssociationGrpc> GetCustomerBusinessUserAssociations(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<bool> PopulateCustomerBusinessUserAssociationsAsync(CancellationToken cancellationToken);

        #endregion

        #region Project

        Task<ListPlatformGrpc> GetAllPlatforms(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<bool> PopulatePlatformsAsync(CancellationToken cancellationToken);
        Task<ListProgramGrpc> GetAllPrograms(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<bool> PopulateProgramsAsync(CancellationToken cancellationToken);
        Task<ListProjectGrpc> GetAllProjects(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<bool> PopulateProjectsAsync(CancellationToken cancellationToken);
        Task<ListMilestoneGrpc> GetAllMilestones(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<bool> PopulateMilestonesAsync(CancellationToken cancellationToken);

        #endregion

        #region Vehicle

        Task<ListVehicleGrpc> GetAllVehicles(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<bool> PopulateVehiclesAsync(CancellationToken cancellationToken);

        #endregion

        #region SupplierGroup

        Task<ListSupplierGroupGrpc> GetAllSupplierGroups(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<bool> PopulateSupplierGroupsAsync(CancellationToken cancellationToken);

        #endregion

        Task HandleFilterCase<T>(string filterExpressionString, ParsingConfig parsingConfig,
            Action<IEnumerable<T>> setResponseCollection, CancellationToken cancellationToken);
    }
}
