namespace Core.Services
{
    public interface ICoreAccessService
    {
        Task<ListUsersGrpc> GetAllUserList(CancellationToken cancellationToken);
        Task<ListUsersGrpc> GetUserListByUserName(ReadUsersListGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateUserList(CancellationToken cancellationToken);
    }
}
