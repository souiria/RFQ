namespace CDb.CQRS.Specification.Masters.CrimpingProcessType
{
    public class GetCrimpingProcessTypesSpecification : Specification<DbCrimpingProcessType>
    {
        public GetCrimpingProcessTypesSpecification(int? position, int? take)
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
