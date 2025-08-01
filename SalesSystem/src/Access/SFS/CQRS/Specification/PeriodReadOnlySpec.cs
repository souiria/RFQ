namespace SFS.CQRS.Specification
{
    class PeriodReadOnlySpec : Specification<DbPeriod>
    {
        public PeriodReadOnlySpec(int? position, int? take)
        {
            int maxTake = 1000;
            if (position != null && take != null)
            {
                Query.Skip(position.Value).Take(take.Value).AsNoTracking();
            }
            else
            {
                Query.Take(maxTake).AsNoTracking();
            }
        }
    }
}
