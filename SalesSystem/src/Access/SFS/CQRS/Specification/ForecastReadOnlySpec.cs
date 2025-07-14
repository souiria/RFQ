namespace SFS.CQRS.Specification
{
    class ForecastReadOnlySpec : Specification<DbForecast>
    {
        public ForecastReadOnlySpec(int? position, int? take)
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
