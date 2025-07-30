namespace EDI.CQRS.Command
{
    record AddEdiFileDuplicateDataCommand(IEnumerable<DbEdiFileDataUploadDuplicate> Data) : ICommand<bool>;
}
