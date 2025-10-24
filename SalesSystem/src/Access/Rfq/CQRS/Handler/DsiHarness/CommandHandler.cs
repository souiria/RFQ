namespace Rfq.CQRS.Handler.DsiHarness
{
    public class CommandHandler : ICommandHandler<DsiHarnessCommand, List<DbDsiHarness>>
    {
        public IRfqRepository<DbDsiHarness> Repository 
        { get; }

        public CommandHandler(IRfqRepository<DbDsiHarness> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbDsiHarness>>> Handle(DsiHarnessCommand command, CancellationToken cancellationToken)
        {
            List<DbDsiHarness> components = command.DsiHarnessGrpcs.Select(x => x.ToEntity()).ToList();
            List<DbDsiHarness> results = new List<DbDsiHarness>();
            results.Clear();
            IEnumerable<DbDsiHarness> repositoryActionResult;
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
                    Result<List<DbDsiHarness>> failedResult = new Result<List<DbDsiHarness>>(results, false, error);
                    return failedResult;
                }
            }

            Result<List<DbDsiHarness>> result;
            if (success)
            {
                result = new Result<List<DbDsiHarness>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error("Failure", $"Command type {command.CommandType} failed!", ErrorType.Problem);
                result = new Result<List<DbDsiHarness>>(results, false, error);
            }

            return result;
        }
    }
}
