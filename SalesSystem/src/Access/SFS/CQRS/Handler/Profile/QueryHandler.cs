
namespace SFS.CQRS.Handler.Profile
{
    public class QueryHandler : IQueryHandler<GetProfileQuery, List<ProfileViewGrpc>>
    {
         readonly ISFSReadRepository<DbProfile> _Repository;
         List<ProfileViewGrpc> _Profile;

        public QueryHandler(ISFSReadRepository<DbProfile> repository)
        {
            _Repository = repository;
            _Profile = [];
        }

        public async Task<Result<List<ProfileViewGrpc>>> Handle(GetProfileQuery query, CancellationToken cancellationToken)
        {
            _Profile.Clear();

            ProfileReadOnlySpec spec = new ProfileReadOnlySpec(query.Position, query.TakeAmount);
            List<DbProfile> results = await _Repository.ListAsync(spec, cancellationToken);

            foreach (DbProfile result in results)
            {
                ProfileViewGrpc profileData = result.MapToProfileGrpc();
                _Profile.Add(profileData);
            }

            return _Profile;
        }
    }

}
