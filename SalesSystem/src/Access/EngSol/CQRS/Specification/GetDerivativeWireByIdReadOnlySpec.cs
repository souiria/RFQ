namespace EngSol.CQRS.Specification
{
    public class GetDerivativeWireByIdReadOnlySpec : Specification<DbDerivativeWires>
    {
        public GetDerivativeWireByIdReadOnlySpec(int? id)
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
