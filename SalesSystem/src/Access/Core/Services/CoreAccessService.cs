namespace Core.Services
{
    public class CoreAccessService : ICoreAccessService
    {
        #region In Memory Datasets

        #region User List

        ListUsersGrpc _ListUsers;
        #endregion

        #endregion

        #region Fields and Properties

        #region User List

        IQueryHandler<GetAllUsersQuery, List<UserListGrpc>>? _UserListHandler;
        bool _UserListRefreshInProgress;
        #endregion

        readonly IServiceProvider _ServiceProvider;

        #endregion

        #region Constructor
        public CoreAccessService(IServiceProvider serviceProvider, bool testing = false)
        {
            #region User List

            _ListUsers = new ListUsersGrpc();
            _UserListRefreshInProgress = false;

            #endregion

            _ServiceProvider = serviceProvider;

            if (!testing)
            {
            }
        }
        #endregion

        #region Handlers

        public async Task<ListUsersGrpc> GetAllUserList(CancellationToken cancellationToken)
        {
            await Task.Delay(0, cancellationToken);
            if (_ListUsers.Users.Any())
            {
                return _ListUsers;
            }
            else
            {
                await PopulateUserList(cancellationToken);
                return _ListUsers;
            }
        }

        public async Task<ListUsersGrpc> GetUserListByUserName(ReadUsersListGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(0, cancellationToken);
            if (_ListUsers.Users.Any())
            {
            }
            else
            {
                await PopulateUserList(cancellationToken);
            }

            ListUsersGrpc responseList = new ListUsersGrpc();
            List<UserListGrpc> users = _ListUsers.Users.Where(x => x.Username == request.GrpcRequestParameter.StringValue).ToList();
            if (users != null)
            {
                responseList.Users.AddRange(users);
                return responseList;
            }

            return responseList;
        }

        #endregion

        #region Data Imports

        public async Task<bool> PopulateUserList(CancellationToken cancellationToken)
        {
            if (!_UserListRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _UserListHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetAllUsersQuery, List<UserListGrpc>>>();
                    _UserListRefreshInProgress = true;
                    GetAllUsersQuery query = new GetAllUsersQuery();
                    await Task.Delay(0, cancellationToken);
                    Result<List<UserListGrpc>> results = await _UserListHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListUsers.Users.Clear();
                        _ListUsers.Users.AddRange(results.Value);
                    }

                    _UserListRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        #endregion
    }
}
