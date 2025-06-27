namespace Master.Services
{
    public interface IMasterAccessService
    {
        #region Currency
        Task<ListCurrencyGrpc> GetAllCurrencies(CancellationToken cancellationToken);
        Task<ListCurrencyGrpc> GetCurrenciesById(string id ,CancellationToken cancellationToken);
        Task<bool> PopulateCurrenciesAsync(CancellationToken cancellationToken);
        #endregion

        #region Customer

        Task<ListCustomerGrpc> GetAllCustomerBusinessUnits(CancellationToken cancellationToken);
        Task<ListCustomerGrpc> GetCustomerBusinessUnitsById(string id ,CancellationToken cancellationToken);
        Task<bool> PopulateCustomersAsync(CancellationToken cancellationToken);
        Task<ListCustomerLocationGrpc> GetAllCustomerLocations(CancellationToken cancellationToken);
        Task<ListCustomerLocationGrpc> GetCustomerLocationsById(string id, CancellationToken cancellationToken);
        Task<ListCustomerLocationGrpc> GetCustomerLocationsByUserId(string userId, CancellationToken cancellationToken);
        Task<bool> PopulateCustomerLocationsAsync(CancellationToken cancellationToken);
        Task<ListCustomerProjectAssociationGrpc> GetAllCustomerProjectAssociations(CancellationToken cancellationToken);
        Task<ListCustomerProjectAssociationGrpc> GetAllCustomerProjectAssociationsByUserId(string userId,CancellationToken cancellationToken);
        Task<bool> PopulateCustomerProjectAssociationsAsync(CancellationToken cancellationToken);
        Task<ListCustomerSalesEntityGrpc> GetAllCustomerSalesEntities(CancellationToken cancellationToken);
        Task<ListCustomerSalesEntityGrpc> GetAllCustomerSalesByUserIdEntities(string userId, CancellationToken cancellationToken);
        Task<bool> PopulateCustomerSalesEntitiesAsync(CancellationToken cancellationToken);
        Task<ListCustomerBusinessUserAssociationGrpc> GetCustomerBusinessUserAssociations(CancellationToken cancellationToken);
        Task<ListCustomerBusinessUserAssociationGrpc> GetCustomerBusinessUserAssociationsByUserId(string userId, CancellationToken cancellationToken);
        Task<bool> PopulateCustomerBusinessUserAssociationsAsync(CancellationToken cancellationToken);

        #endregion

        #region Project

        Task<ListPlatformGrpc> GetAllPlatforms(CancellationToken cancellationToken);
        Task<ListPlatformGrpc> GetPlatformsById(string id,CancellationToken cancellationToken);
        Task<bool> PopulatePlatformsAsync(CancellationToken cancellationToken);
        Task<ListProgramGrpc> GetAllPrograms(CancellationToken cancellationToken);
        Task<ListProgramGrpc> GetProgramsById(string id, CancellationToken cancellationToken);
        Task<bool> PopulateProgramsAsync(CancellationToken cancellationToken);
        Task<ListProjectGrpc> GetAllProjects(CancellationToken cancellationToken);
        Task<ListProjectGrpc> GetProjectsById(string id, CancellationToken cancellationToken);
        Task<bool> PopulateProjectsAsync(CancellationToken cancellationToken);
        Task<ListMilestoneGrpc> GetAllMilestones(CancellationToken cancellationToken);
        Task<ListMilestoneGrpc> GetMilestonesById(string id, CancellationToken cancellationToken);
        Task<bool> PopulateMilestonesAsync(CancellationToken cancellationToken);

        #endregion

        #region Vehicle

        Task<ListVehicleGrpc> GetAllVehicles(CancellationToken cancellationToken);
        Task<bool> PopulateVehiclesAsync(CancellationToken cancellationToken);
        Task<ListVehicleGrpc> GetVehiclesById(string id, CancellationToken cancellationToken);
        Task<ListVehicleGrpc> GetVehiclesByDisplay(string vehicleDisplay, CancellationToken cancellationToken);

        #endregion
    }
}
