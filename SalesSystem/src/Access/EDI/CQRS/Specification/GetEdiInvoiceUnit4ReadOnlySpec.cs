namespace EDI.CQRS.Specification
{
    public class GetEdiInvoiceUnit4ReadOnlySpec : Specification<DbEdiInvoiceUnit4>
    {
        public GetEdiInvoiceUnit4ReadOnlySpec()
        {
            Query
                .AsNoTracking();
        }
    }
}
