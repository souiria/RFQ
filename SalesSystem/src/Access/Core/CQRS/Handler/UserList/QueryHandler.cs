namespace Core.CQRS.Handler.UserList
{
    public class QueryHandler : IQueryHandler<GetAllUsersQuery, List<UserListGrpc>>
    {
        readonly ICoreRepository<DbUserList> _Repository;
        List<UserListGrpc> _Users;

        public QueryHandler(ICoreRepository<DbUserList> repository)
        {
            _Repository = repository;
            _Users = [];
        }

        public async Task<Result<List<UserListGrpc>>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
        {
            _Users.Clear();
            GetUserListReadOnlySpec spec = new GetUserListReadOnlySpec(query.Position, query.TakeAmount);
            List<DbUserList> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbUserList result in results)
            {
                UserListGrpc userGrpc = result.MapToListUsersGrpc();
                _Users.Add(userGrpc);
            }

            return _Users;
        }
    }
}
