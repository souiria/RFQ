namespace Edi.Api.Access.CQRS.Specifications;
internal sealed class GetEdiInvoiceInformationReadOnlySpec : Specification<DbEdiInvoiceInformation>
{
    public GetEdiInvoiceInformationReadOnlySpec()
    {
        Query
            .AsNoTracking();
    }
}
