namespace SFS.CQRS.Specification
{
   public class CalculationTypeReadOnlySpec : Specification<DbCalculationType>
    {
        public CalculationTypeReadOnlySpec(int? position, int? take)
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
