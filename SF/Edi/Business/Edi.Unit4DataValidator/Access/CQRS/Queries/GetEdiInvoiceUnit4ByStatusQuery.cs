namespace Edi.Unit4DataValidator.Access.CQRS.Queries;
internal class GetEdiInvoiceUnit4ByStatusQuery : IRequest<List<EdiInvoiceInformationDto>>
{
    public EdiInvoiceStatus EdiInvoiceStatus { get; set; }
}
