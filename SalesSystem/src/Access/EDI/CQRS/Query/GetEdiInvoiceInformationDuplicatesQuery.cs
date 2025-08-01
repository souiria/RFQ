namespace EDI.CQRS.Query
{
    class GetEdiInvoiceInformationDuplicatesQuery : IQuery<List<EdiInvoiceInformationDuplicateGrpc>>;
}
