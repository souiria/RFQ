namespace EDI.CQRS.Command
{
    record AddEdiInvoiceUnit4Command(IEnumerable<DbEdiInvoiceUnit4> Data) : ICommand<bool>;
}
