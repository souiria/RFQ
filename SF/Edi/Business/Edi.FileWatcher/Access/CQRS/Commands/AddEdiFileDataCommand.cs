namespace Edi.FileWatcher.Access.CQRS.Commands;
internal record AddEdiFileDataCommand(IEnumerable<DbEdiFileDataUpload> Data) : IRequest<bool>;
