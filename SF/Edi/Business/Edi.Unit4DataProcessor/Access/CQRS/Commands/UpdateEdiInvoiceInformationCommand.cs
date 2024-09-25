namespace Edi.Unit4DataProcessor.Access.CQRS.Commands;
internal record UpdateEdiInvoiceInformationCommand(IEnumerable<DbEdiInvoiceInformation> EdiInvoiceInformation) : IRequest<bool>;

