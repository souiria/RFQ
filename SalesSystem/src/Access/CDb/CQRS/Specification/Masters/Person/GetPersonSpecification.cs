namespace CDb.CQRS.Specification.Masters.Person
{
    public class GetPersonsSpecification : Specification<DbPerson>
    {
        public GetPersonsSpecification(int? position, int? take)
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
