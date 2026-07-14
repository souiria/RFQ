namespace EDI.CQRS.Command
{
    record AddZeroPriceExceptionsCommand(IEnumerable<DbZeroPriceExceptions> Data) : ICommand<bool>;
}
