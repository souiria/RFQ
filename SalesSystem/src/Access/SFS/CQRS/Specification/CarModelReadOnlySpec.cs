namespace SFS.CQRS.Specification
{
    public class CarModelReadOnlySpec : Specification<DbCarModel>
    {
        public CarModelReadOnlySpec(int? position, int? take)
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

