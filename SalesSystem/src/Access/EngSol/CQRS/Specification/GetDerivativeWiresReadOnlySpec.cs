using Ardalis.Specification;

namespace EngSol.CQRS.Specification
{
    public class GetDerivativeWiresReadOnlySpec : Specification<DbDerivativeWires>
    {
        public GetDerivativeWiresReadOnlySpec(int? position, int? take)
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
