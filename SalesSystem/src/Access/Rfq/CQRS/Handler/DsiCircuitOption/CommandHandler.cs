namespace Rfq.CQRS.Handler.DsiCircuitOption
{
    public class CommandHandler : ICommandHandler<DsiCircuitOptionCommand, List<DbDsiCircuitOption>>
    {
        public IRfqRepository<DbDsiCircuitOption> Repository 
        { get; }

        public CommandHandler(IRfqRepository<DbDsiCircuitOption> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbDsiCircuitOption>>> Handle(DsiCircuitOptionCommand command, CancellationToken cancellationToken)
        {
            List<DbDsiCircuitOption> components = command.DsiCircuitOptionGrpcs.Select(x => x.ToEntity()).ToList();
            List<DbDsiCircuitOption> results = new List<DbDsiCircuitOption>();
            results.Clear();
            IEnumerable<DbDsiCircuitOption> repositoryActionResult;
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
                    Result<List<DbDsiCircuitOption>> failedResult = new Result<List<DbDsiCircuitOption>>(results, false, error);
                    return failedResult;
                }
            }

            Result<List<DbDsiCircuitOption>> result;
            if (success)
            {
                result = new Result<List<DbDsiCircuitOption>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error("Failure", $"Command type {command.CommandType} failed!", ErrorType.Problem);
                result = new Result<List<DbDsiCircuitOption>>(results, false, error);
            }

            return result;
        }
    }
}
