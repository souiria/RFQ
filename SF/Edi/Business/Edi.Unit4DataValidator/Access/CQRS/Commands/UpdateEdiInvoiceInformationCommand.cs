namespace Edi.Unit4DataValidator.Access.CQRS.Commands;
internal record UpdateEdiInvoiceInformationCommand(IEnumerable<DbEdiInvoiceInformation> EdiInvoiceInformation) : IRequest<bool>;

