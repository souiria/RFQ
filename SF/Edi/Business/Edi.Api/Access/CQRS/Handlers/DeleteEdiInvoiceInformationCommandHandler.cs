namespace Edi.Api.Access.CQRS.Handlers;

internal class DeleteEdiInvoiceInformationCommandHandler : IRequestHandler<DeleteEdiInvoiceInformationCommand>
{
    private readonly ISalesEdiRepository<DbEdiFileDataUploadDuplicate> _repository;

    public DeleteEdiInvoiceInformationCommandHandler(ISalesEdiRepository<DbEdiFileDataUploadDuplicate> repository) => _repository = repository;

    public async Task Handle(DeleteEdiInvoiceInformationCommand request, CancellationToken cancellationToken)
    {
        foreach (var duplicate in request.Duplicates)
        {
            await _repository.DeleteRangeAsync(new DeleteDuplicatesSpec(duplicate.FileName, duplicate.DispatchNumber), cancellationToken);
        }
    }
}
