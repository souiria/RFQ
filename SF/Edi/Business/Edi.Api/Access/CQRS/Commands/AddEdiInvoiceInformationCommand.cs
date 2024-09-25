namespace Edi.Api.Access.CQRS.Commands;
internal record AddEdiInvoiceInformationCommand(IEnumerable<DbEdiInvoiceInformation> Data) : IRequest<bool>;
