namespace Edi.Unit4DataValidator.Access.CQRS.Commands;

internal record AddEdiInvoiceUnit4Command(IEnumerable<DbEdiInvoiceUnit4> EdiInvoiceUnit4) : IRequest<bool>;
