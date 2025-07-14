namespace SFS.CQRS.Specification
{
    class SiteReadOnlySpec : Specification<DbSite>
    {
        public SiteReadOnlySpec(int? position, int? take)
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
