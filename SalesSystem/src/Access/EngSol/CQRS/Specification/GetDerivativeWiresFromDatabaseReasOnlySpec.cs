namespace EngSol.CQRS.Specification
{
    public class GetDerivativeWiresFromDatabaseReasOnlySpec : Specification<DbDerivativeWires>
    {
        public GetDerivativeWiresFromDatabaseReasOnlySpec(int? position, int? take)
        {
            if (position != null && take != null)
            {
                Query.Skip(position.Value).Take(take.Value).OrderByDescending(x => x.DerivativeId).AsNoTracking();
            }
            else
            {
                Query.AsNoTracking();
            }
        }
    }
}
