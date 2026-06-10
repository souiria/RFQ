namespace Master.CQRS.Specification.BusinessUnit
{
    public class GetBusinessUnitsReadOnlySpec : Specification<DbBusinessUnit>
    {
        public GetBusinessUnitsReadOnlySpec(int? position, int? take)
        {
            Query.Where(x => x.IsActive == true);

            if (position != null && take != null)
            {
                Query.Skip(position.Value)
                     .Take(take.Value)
                     .AsNoTracking();
            }
            else
            {
                Query.AsNoTracking();
            }
        }
    }
}
