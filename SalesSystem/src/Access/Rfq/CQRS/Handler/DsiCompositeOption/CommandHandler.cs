namespace Rfq.CQRS.Handler.DsiCompositeOption
{
    public class CommandHandler : ICommandHandler<DsiCompositeOptionCommand, List<DbDsiCompositeOption>>
    {
        public IRfqRepository<DbDsiCompositeOption> Repository
        { get; }

        public CommandHandler(IRfqRepository<DbDsiCompositeOption> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbDsiCompositeOption>>> Handle(DsiCompositeOptionCommand command, CancellationToken cancellationToken)
        {
            List<DbDsiCompositeOption> components = command.DsiCompositeOptionGrpcs.Select(x => x.ToEntity()).ToList();
            List<DbDsiCompositeOption> results = new List<DbDsiCompositeOption>();
            results.Clear();
            IEnumerable<DbDsiCompositeOption> repositoryActionResult;
            int updateDeleteCount = 0;
            bool success = false;

            switch (command.CommandType)
            {
                case CommandType.Create:
                repositoryActionResult = await Repository.AddRangeAsync(components, cancellationToken);
                success = repositoryActionResult.Count() == components.Count;
                results = repositoryActionResult.ToList();
                break;
                case CommandType.Update:
                updateDeleteCount = await Repository.UpdateRangeAsync(components, cancellationToken);
                success = updateDeleteCount == components.Count;
                break;
                case CommandType.Delete:
                updateDeleteCount = await Repository.DeleteRangeAsync(components, cancellationToken);
                success = updateDeleteCount == components.Count;
                break;
                default:
                {
                    Error error = new Error("InvalidCommand", "The command type is not supported.", ErrorType.Failure);
                    Result<List<DbDsiCompositeOption>> failedResult = new Result<List<DbDsiCompositeOption>>(results, false, error);
                    return failedResult;
                }
            }

            Result<List<DbDsiCompositeOption>> result;
            if (success)
            {
                result = new Result<List<DbDsiCompositeOption>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error("Failure", $"Command type {command.CommandType} failed!", ErrorType.Problem);
                result = new Result<List<DbDsiCompositeOption>>(results, false, error);
            }

            return result;
        }
    }
}
