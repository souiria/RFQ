namespace SFS.CQRS.Specification
{
    public class CarModelReadOnlySpec : Specification<DbCarModel>
    {
        public CarModelReadOnlySpec(int? position, int? take)
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

