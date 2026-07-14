namespace EDI.CQRS.Command
{
    record AddEdiInvoiceInformationCommand(IEnumerable<DbEdiInvoiceInformation> Data) : ICommand<bool>;
}
