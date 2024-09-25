namespace Edi.FileWatcher.Access.CQRS.Commands;
internal record AddEdiFileDuplicateDataCommand(IEnumerable<DbEdiFileDataUploadDuplicate> Data) : IRequest<bool>;
