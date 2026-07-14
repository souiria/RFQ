namespace Core.CQRS.Specification.UserList
{
    public class GetUserListReadOnlySpec : Specification<DbUserList>
    {
        public GetUserListReadOnlySpec(int? position, int? take)
        {
            if (position != null && take != null)
            {
                Query.Skip(position.Value).Take(take.Value).AsNoTracking();
            }
            else
            {
                Query.AsNoTracking();
            }
        }
    }
}
