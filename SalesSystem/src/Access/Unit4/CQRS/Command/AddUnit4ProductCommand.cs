namespace Unit4.CQRS.Command
{
    record AddUnit4ProductCommand(DbAlgProductInput ProductData) : ICommand<bool>;
}
