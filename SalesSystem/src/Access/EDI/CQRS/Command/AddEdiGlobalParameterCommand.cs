namespace EDI.CQRS.Command
{
    record AddEdiGlobalParameterCommand(IEnumerable<DbEdiGlobalParameter> Data) : ICommand<bool>;
}
