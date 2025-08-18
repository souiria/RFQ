namespace Unit4.CQRS.Command
{
    record AddDispatchToUnit4Command(IEnumerable<DbAlgBatchInput> Unit4AlgBatchInput) : ICommand<bool>;
}
