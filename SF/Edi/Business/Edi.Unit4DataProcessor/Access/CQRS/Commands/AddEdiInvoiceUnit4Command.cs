namespace Edi.Unit4DataProcessor.Access.CQRS.Commands;

internal record AddEdiInvoiceUnit4Command(IEnumerable<DbEdiInvoiceUnit4> EdiInvoiceUnit4) : IRequest<bool>;
