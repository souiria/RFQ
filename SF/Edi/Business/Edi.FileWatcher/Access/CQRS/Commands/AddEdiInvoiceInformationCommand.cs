namespace Edi.FileWatcher.Access.CQRS.Commands;
internal record AddEdiInvoiceInformationCommand(IEnumerable<DbEdiInvoiceInformation> Data) : IRequest<bool>;
