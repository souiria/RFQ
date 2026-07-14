namespace Core.CQRS.Query.UserList
{
    public class GetAllUsersQuery : IQuery<List<UserListGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
