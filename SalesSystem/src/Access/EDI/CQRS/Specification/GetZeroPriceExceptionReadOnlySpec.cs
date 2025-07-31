namespace EDI.CQRS.Specification
{
    public class GetZeroPriceExceptionReadOnlySpec : Specification<DbZeroPriceExceptions>
    {
        public GetZeroPriceExceptionReadOnlySpec()
        {
            Query
                .AsNoTracking();
        }
    }
}
