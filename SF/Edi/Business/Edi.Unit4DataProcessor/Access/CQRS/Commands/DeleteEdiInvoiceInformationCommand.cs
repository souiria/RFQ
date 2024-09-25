namespace Edi.Unit4DataProcessor.Access.CQRS.Commands;
internal record DeleteEdiInvoiceInformationCommand(IEnumerable<DbEdiInvoiceInformation> EdiInvoiceInformation) : IRequest<bool>;