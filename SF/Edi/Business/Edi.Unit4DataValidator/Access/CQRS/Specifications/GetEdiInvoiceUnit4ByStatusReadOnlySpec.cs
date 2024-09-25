namespace Edi.Unit4DataValidator.Access.CQRS.Specifications;
internal sealed class GetEdiInvoiceUnit4ByStatusReadOnlySpec : Specification<DbEdiInvoiceUnit4>
{
    public GetEdiInvoiceUnit4ByStatusReadOnlySpec(EdiInvoiceStatus ediInvoiceStatus)
    {
        Query.Where(x => x.Status == ediInvoiceStatus).AsNoTracking();
    }
}