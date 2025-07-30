namespace CDb.CQRS.Specification.TemperatureRange
{
    public class GetTemperatureRangesSpecification : Specification<DbTemperatureRange>
    {
        public GetTemperatureRangesSpecification(int? position, int? take)
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
