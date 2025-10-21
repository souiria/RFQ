namespace Rfq.CQRS.Handler.DsiTransformedHarness
{
    public class CommandHandler : ICommandHandler<DsiTransformedHarnessCommand, List<DbDsiTransformedHarness>>
    {
        public IRfqRepository<DbDsiTransformedHarness> Repository
        { get; }

        public CommandHandler(IRfqRepository<DbDsiTransformedHarness> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbDsiTransformedHarness>>> Handle(DsiTransformedHarnessCommand command, CancellationToken cancellationToken)
        {
            List<DbDsiTransformedHarness> components = command.DsiTransformedHarnessGrpcs.Select(x => x.ToEntity()).ToList();
            List<DbDsiTransformedHarness> results = new List<DbDsiTransformedHarness>();
            results.Clear();
            IEnumerable<DbDsiTransformedHarness> repositoryActionResult;
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
                    Result<List<DbDsiTransformedHarness>> failedResult = new Result<List<DbDsiTransformedHarness>>(results, false, error);
                    return failedResult;
                }
            }

            Result<List<DbDsiTransformedHarness>> result;
            if (success)
            {
                result = new Result<List<DbDsiTransformedHarness>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error("Failure", $"Command type {command.CommandType} failed!", ErrorType.Problem);
                result = new Result<List<DbDsiTransformedHarness>>(results, false, error);
            }

            return result;
        }
    }
}
