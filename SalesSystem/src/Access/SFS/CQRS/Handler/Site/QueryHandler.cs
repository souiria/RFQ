
namespace SFS.CQRS.Handler.Site
{
    public class QueryHandler : IQueryHandler<GetSiteQuery, List<SiteViewGrpc>>
    {
         readonly ISFSReadRepository<DbSite> _Repository;
        List<SiteViewGrpc> _Site;

        public QueryHandler(ISFSReadRepository<DbSite> repository)
        {
            _Repository = repository;
            _Site = [];
        }
        public async Task<Result<List<SiteViewGrpc>>> Handle(GetSiteQuery query, CancellationToken cancellationToken)
        {
            _Site.Clear();

            SiteReadOnlySpec spec = new SiteReadOnlySpec(query.Position, query.TakeAmount);
            List<DbSite> results = await _Repository.ListAsync(spec, cancellationToken);

            foreach (DbSite result in results)
            {
                SiteViewGrpc siteData = result.MapToSiteGrpc();
                _Site.Add(siteData);
            }

            return _Site;
        }
    }
   }
