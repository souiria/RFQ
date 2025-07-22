namespace SFS.Services
{
    public interface ISFSAccessService
    {
        Task<CarModelListViewGrpc> GetAllCarModel(CancellationToken cancellationToken);
    }
}
