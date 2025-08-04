namespace EDI.CQRS.Command
{
    record AddEdiCustomerParameterCommand(IEnumerable<DbEdiCustomerParameter> Data) : ICommand<bool>;
}
