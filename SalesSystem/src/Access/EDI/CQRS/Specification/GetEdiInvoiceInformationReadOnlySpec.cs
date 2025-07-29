namespace EDI.CQRS.Specification
{
    public class GetEdiInvoiceInformationReadOnlySpec : Specification<DbEdiInvoiceInformation>
    {
        public GetEdiInvoiceInformationReadOnlySpec()
        {
            Query
                .AsNoTracking();
        }
    }
}
