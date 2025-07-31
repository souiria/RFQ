namespace EDI.CQRS.Command
{
    record AddEdiFileDataCommand(IEnumerable<DbEdiFileDataUpload> Data) : ICommand<bool>;
}
