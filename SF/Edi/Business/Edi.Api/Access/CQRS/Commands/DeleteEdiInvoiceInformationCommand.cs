namespace Edi.Api.Access.CQRS.Commands;

public record DeleteEdiInvoiceInformationCommand(IEnumerable<DuplicateDataDto> Duplicates) : IRequest;
