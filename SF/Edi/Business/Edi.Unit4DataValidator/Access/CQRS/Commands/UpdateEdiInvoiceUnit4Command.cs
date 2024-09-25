namespace Edi.Unit4DataValidator.Access.CQRS.Commands;
internal record UpdateEdiInvoiceUnit4Command(IEnumerable<DbEdiInvoiceUnit4> EdiInvoiceUnit4) : IRequest<bool>;