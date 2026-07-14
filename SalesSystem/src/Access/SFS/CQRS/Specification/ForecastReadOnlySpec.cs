namespace SFS.CQRS.Specification
{
    class ForecastReadOnlySpec : Specification<DbForecast>
    {
        public ForecastReadOnlySpec(int? position, int? take)
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
