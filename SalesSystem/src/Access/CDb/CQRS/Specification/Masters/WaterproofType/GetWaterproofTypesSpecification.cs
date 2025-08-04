namespace CDb.CQRS.Specification.Masters.WaterproofType
{
    public class GetWaterproofTypesSpecification : Specification<DbWaterproofType>
    {
        public GetWaterproofTypesSpecification(int? position, int? take)
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
