namespace EDI.CQRS.Specification
{
    public class GetEdiInvoiceInformationDuplicateReadOnlySpec : Specification<DbEdiInvoiceInformationDuplicate>
    {
        public GetEdiInvoiceInformationDuplicateReadOnlySpec()
        {
            Query
                .AsNoTracking();
        }
    }
}
