namespace EDI.CQRS.Specification
{
    public class GetGlobalParameterReadOnlySpec : Specification<DbEdiGlobalParameter>
    {
        public GetGlobalParameterReadOnlySpec()
        {
            Query
                .AsNoTracking();
        }
    }
}
