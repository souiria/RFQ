namespace Edi.Api.Access.CQRS.Commands;
internal record UpdateEdiFileDuplicateDataCommand(IEnumerable<DbEdiFileDataUploadDuplicate> Data) : IRequest<bool>;
