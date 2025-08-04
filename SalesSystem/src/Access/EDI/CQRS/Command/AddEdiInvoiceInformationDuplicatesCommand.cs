namespace EDI.CQRS.Command
{
    record AddEdiInvoiceInformationDuplicatesCommand(IEnumerable<DbEdiInvoiceInformationDuplicate> Data) : ICommand<bool>;
}
