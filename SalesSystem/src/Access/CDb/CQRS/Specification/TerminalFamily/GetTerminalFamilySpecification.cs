namespace CDb.CQRS.Specification.TerminalFamily
{
    public class GetTerminalFamilysSpecification : Specification<DbTerminalFamily>
    {
        public GetTerminalFamilysSpecification(int? position, int? take)
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
