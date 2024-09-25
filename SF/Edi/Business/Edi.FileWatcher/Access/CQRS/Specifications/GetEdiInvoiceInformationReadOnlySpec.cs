namespace Edi.FileWatcher.Access.CQRS.Specifications;
internal sealed class GetEdiInvoiceInformationReadOnlySpec : Specification<DbEdiInvoiceInformation>
{
    public GetEdiInvoiceInformationReadOnlySpec()
    {
        Query
            .AsNoTracking();
    }
}
