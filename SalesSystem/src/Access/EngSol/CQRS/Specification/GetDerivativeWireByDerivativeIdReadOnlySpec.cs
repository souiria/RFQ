namespace EngSol.CQRS.Specification
{
    public class GetDerivativeWireByDerivativeIdReadOnlySpec : Specification<DbDerivativeWires>
    {
        public GetDerivativeWireByDerivativeIdReadOnlySpec(int? id)
        {
            if (0 < id)
            {
                Query.Where(x => x.DerivativeId == id).AsNoTracking();
            }
            else
            {
                Query.AsNoTracking();
            }
        }
    }
}
