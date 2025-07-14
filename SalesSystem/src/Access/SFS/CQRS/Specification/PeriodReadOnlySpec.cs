namespace SFS.CQRS.Specification
{
    class PeriodReadOnlySpec : Specification<DbPeriod>
    {
        public PeriodReadOnlySpec(int? position, int? take)
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
